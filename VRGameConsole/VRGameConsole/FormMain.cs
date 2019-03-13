using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.Controller = new Controller(this.Model);
            this.Controller.LoadSettings();
            this.RefreshGamesList();
            this.ComboBoxLimitTime.Items.AddRange(new string[] { "1", "5", "10", "30" });
            this.Model.Worker.ProgressChanged += Worker_ProgressChanged;
            this.Model.Worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            this.Model.Worker.DoWork += Worker_DoWork;
            this.Model.Worker.RunWorkerAsync();
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
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
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

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

            var g = new OperationRecordModel();
            g.App = this.Model.AppList.Single(m => string.Compare(m.Name, game, true) == 0);
            g.LimitMinutes = limit;
            this.Model.RunningApps.Add(g);
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
            }
        }
    }
}
