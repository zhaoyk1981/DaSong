using DaSongXuanCi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DaSongXuanCi.Pages;

namespace DaSongXuanCi
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private ViewModel Model { get; set; }

        private Controller Controller { get; set; }

        private Button 当前按钮 { get; set; }

        private string 当前按钮文字 { get; set; }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.初始化();
        }

        private void 初始化()
        {
            this.Model = new ViewModel();
            this.Controller = new Controller(this.Model);
            this.加载设置();
            this.Model.Worker.ProgressChanged += Worker_ProgressChanged;
            this.Model.Worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            this.Model.Worker.DoWork += Worker_DoWork;
        }

        private void 加载设置()
        {

        }

        private bool 收集信息()
        {
            return true;
        }

        private bool 验证()
        {
            return true;
        }

        private void 保存设置()
        {

        }

        private void 禁用控件()
        {

        }

        private void 启用控件()
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                this.Controller.开始操作();
            }
            catch (Exception ex)
            {
                this.Model.Worker.ReportProgress(0, new UserStateModel("程序出错", ex));
            }

            e.Cancel = this.Model.Worker.CancellationPending;
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var userState = e.UserState as UserStateModel;
            if (userState == null)
            {
                return;
            }

            if (userState.需要手动登录)
            {
                this.Model.手动登录 = false;
                //this.当前按钮.Text = "继续";
                if (MessageBox.Show(this, "程序暂停，请手动登录后点击\"OK\"", "手动登录", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    this.Model.手动登录 = true;
                }
            }
            //this.显示信息($"{userState.GetMessage(ViewModel.每天完成手数)}");
            //if (userState.需要登录验证码)
            //{
            //    switch (this.Model.操作)
            //    {
            //        case 操作.THSC成交记录:
            //            {
            //                this.BtnTHSC交易记录.Text = "继续";
            //                break;
            //            }
            //        case 操作.EHE成交记录:
            //            {
            //                this.BtnEHE交易记录.Text = "继续";
            //                break;
            //            }
            //        case 操作.CAO交易记录:
            //            {
            //                this.BtnCAO交易记录.Text = "继续";
            //                break;
            //            }
            //    }
            //}

            //if (userState.Exception != null && !this.Model.零售模式)
            //{
            //    this.显示信息($"{userState.Exception.StackTrace}");
            //    this.显示信息($"{userState.Exception.Message}");
            //    if (userState.Exception.InnerException != null)
            //    {
            //        this.显示信息($"{userState.Exception.InnerException.StackTrace}");
            //        this.显示信息($"{userState.Exception.InnerException.Message}");
            //    }
            //}
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var wr = e.Cancelled ? new WorkResultModel() { 成功 = true, Message = "操作已取消" } : e.Result as WorkResultModel;
            this.还原按钮();
        }

        private void Btn分析数据_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            switch (btn.Text)
            {
                case "停止":
                    {
                        this.Model.Worker.CancelAsync();
                        btn.Text = "正在停止";
                        break;
                    }
                case "继续":
                    {
                        this.Model.手动登录 = true;
                        btn.Text = "停止";
                        break;
                    }
                default:
                    {
                        if (!this.收集信息())
                        {
                            return;
                        }

                        if (!this.验证())
                        {
                            return;
                        }

                        this.保存设置();
                        this.备份按钮(btn);
                        this.禁用控件();
                        this.Model.当前操作 = 操作.分析数据;
                        this.开始();
                        break;
                    }
            }
        }

        private void 备份按钮(Button btn)
        {
            this.当前按钮 = btn;
            this.当前按钮文字 = btn.Text;
            btn.Text = "停止";
        }

        private void 还原按钮()
        {
            this.当前按钮.Text = this.当前按钮文字;
        }

        private void 开始()
        {
            if (this.Model.零售模式)
            {
                //if (!this.验证激活())
                //{
                //    Application.Exit();
                //    return;
                //}
            }

            this.Model.Worker.RunWorkerAsync();
        }
    }
}
