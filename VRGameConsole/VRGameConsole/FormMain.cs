using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using VRGameConsole.Models;

namespace VRGameConsole
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private ViewModel Model { get; set; } = new ViewModel();

        public Controller Controller { get; set; }

        private void BtnAddGame_Click(object sender, EventArgs e)
        {
            if (this.ChooseGameDialog.ShowDialog() == DialogResult.OK)
            {
                var fileName = this.ChooseGameDialog.FileName;
                var newAppForm = new FormEditGame();
                newAppForm.FormMain = this;
                newAppForm.NewAppPath = fileName;
                newAppForm.ShowDialog(this);
            }
        }

        public void RefreshGamesList(string name = null)
        {
            this.ListGames.Items.Clear();
            this.ListGames.Items.AddRange(this.Model.AppList
                .OrderBy(m => m.Name)
                .Select(m => m.Name)
                .ToArray());
            if (!string.IsNullOrEmpty(name))
            {
                this.ListGames.SelectedItem = name;
            }
        }

        public string Mgr { get; set; }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if (string.Compare(this.Mgr, "-management", true) != 0)
            {
                this.BtnAddGame.Visible = false;
                this.BtnRemoveGame.Visible = false;
            }

            this.LblCountDown.Text = string.Empty;
            this.Controller = new Controller(this.Model);
            this.Controller.LoadSettings();
            this.TxtDesc.Text = this.Model.Desc;
            this.RefreshGamesList();

            this.ComboBoxLimitTime.Items.AddRange(this.Controller.GetDefaultLimitDataSource());
            if (string.Compare(ConfigurationManager.AppSettings["InputLimits"], "false", true) == 0)
            {
                if (this.ComboBoxLimitTime.Items.Count == 0)
                {
                    MessageBox.Show("Please set values for limit drop down list in app.config");
                    return;
                }

                this.ComboBoxLimitTime.DropDownStyle = ComboBoxStyle.DropDownList;
                this.ComboBoxLimitTime.SelectedIndex = 0;
            }

            this.ComboBoxLimitTime.Text = ConfigurationManager.AppSettings["DefaultSelectedLimits"];

            this.Model.Worker.ProgressChanged += Worker_ProgressChanged;
            this.Model.Worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            this.Model.Worker.DoWork += Worker_DoWork;
            if (string.Compare(this.Mgr, "-management", true) != 0)
            {
                this.Model.Worker.RunWorkerAsync();
            }

            var vbiz = new ValidationBiz();
            if (!vbiz.Validate(true))
            {
                var vform = new FormValidation();
                vform.FormMain = this;
                vform.ShowDialog(this);
                //this.BtnRunGame.Visible = false;
            }
        }

        public void SetRunGameVisible()
        {
            this.BtnRunGame.Visible = true;
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                this.Model.Worker.ReportProgress(0);
                if (this.Model.Worker.CancellationPending)
                {
                    break;
                }

                this.Controller.Sleep(1);
                if (this.Model.AppList.Count > 0)
                {
                    var ps = Process.GetProcesses()
                        .Where(m => this.Model.AppList.Any(n => string.Compare(n.ProcessName, m.ProcessName, true) == 0))
                        .Select(m => new OperationRecordModel(m, this.Model.AppList))
                        .ToList();
                    this.Controller.CompareProcess(ps);
                }
            }

            e.Cancel = this.Model.Worker.CancellationPending;
            this.Model.Worker.ReportProgress(0);
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var us = e.UserState as UserStateModel;
            if (us != null)
            {
                if (us.CountDown.HasValue)
                {
                    this.LblCountDown.Text = us.CountDown.Value.TotalSeconds > 0
                        ? $"{Convert.ToInt32(Math.Floor(us.CountDown.Value.TotalMinutes)).ToString().PadLeft(2, '0')}:{us.CountDown.Value.Seconds.ToString().PadLeft(2, '0')}"
                        : string.Empty;
                }
            }

            this.SetControlEnabled(this.Model.RunningApps.Count == 0);
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.SetControlEnabled(true);
        }
        private void BtnRemoveGame_Click(object sender, EventArgs e)
        {
            var name = this.ListGames.SelectedItem as string;
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show(this, "Please select a game.", "Remove game", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show(this, $"Are you sure you want to remove \"{name}\"?", $"Remove \"{name}\"", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
            {
                return;
            }

            if (this.Controller.Remove(name))
            {

            }
            else
            {
                MessageBox.Show(this, "Failed to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            this.RefreshGamesList();
        }

        private void BtnRunGame_Click(object sender, EventArgs e)
        {
            var game = this.ListGames.SelectedItem as string;
            if (string.IsNullOrEmpty(game))
            {
                MessageBox.Show(this, "Please select a game.", "Run game", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int limit;
            if (!int.TryParse(this.ComboBoxLimitTime.Text, out limit))
            {
                MessageBox.Show(this, "Please enter the running time.", "Run game", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.OrganizeLimit(limit);
            var g = new OperationRecordModel();
            g.App = this.Model.AppList.Single(m => string.Compare(m.Name, game, true) == 0);
            g.LimitMinutes = limit;
            this.Model.RunningApps.Add(g);
            this.SetControlEnabled(false);
            try
            {
                Process p = new Process();
                p.StartInfo.FileName = g.App.Path;
                p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
                p.StartInfo.CreateNoWindow = true;//不显示程序窗口
                p.Start();//启动程序

            }
            catch (Exception ex)
            {
                this.Model.RunningApps.Remove(g);
                this.SetControlEnabled(true);
            }
        }

        private void SetControlEnabled(bool enabled)
        {
            this.BtnAddGame.Enabled =
                this.BtnRemoveGame.Enabled =
                this.BtnRunGame.Enabled = enabled;
        }

        private void OrganizeLimit(int limit)
        {
            var list = new List<string>();
            foreach (var itm in this.ComboBoxLimitTime.Items)
            {
                var str = itm as string;
                if (string.Compare(str, limit.ToString(), true) == 0)
                {
                    return;
                }

                list.Add(itm as string);
            }

            list.Add(limit.ToString());
            this.ComboBoxLimitTime.Items.Clear();
            this.ComboBoxLimitTime.Items.AddRange(list.OrderByDescending(m => Convert.ToInt32(m)).ToArray());
            this.ComboBoxLimitTime.SelectedItem = limit.ToString();
        }

        private void TxtDesc_TextChanged(object sender, EventArgs e)
        {
            var list = "\\/:*?\"<>|".Select(m => m.ToString()).ToList();
            var str = this.TxtDesc.Text.Trim();
            foreach (var c in list)
            {
                str = str.Replace(c, "");
            }

            this.TxtDesc.Text = this.Model.Desc = str;
            this.Controller.SaveSettings();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(this, "Are you sure you want to close the console application?", "Close console", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.Model.Worker.CancelAsync();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Controller.StopAllRunning();
            this.Controller.ExportExcel();
        }

        private void btnRegKey_Click(object sender, EventArgs e)
        {
            var vform = new FormValidation();
            vform.FormMain = this;
            vform.ShowDialog(this);
        }

    }
}
