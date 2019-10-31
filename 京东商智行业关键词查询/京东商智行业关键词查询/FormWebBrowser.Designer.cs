namespace 京东商智行业关键词查询
{
    partial class FormWebBrowser
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.webControl1 = new EO.WinForm.WebControl();
            this.webView1 = new EO.WebBrowser.WebView();
            this.SuspendLayout();
            // 
            // webControl1
            // 
            this.webControl1.BackColor = System.Drawing.Color.White;
            this.webControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webControl1.Location = new System.Drawing.Point(0, 0);
            this.webControl1.Name = "webControl1";
            this.webControl1.Size = new System.Drawing.Size(1670, 911);
            this.webControl1.TabIndex = 0;
            this.webControl1.Text = "webControl1";
            this.webControl1.WebView = this.webView1;
            // 
            // webView1
            // 
            this.webView1.InputMsgFilter = null;
            this.webView1.ObjectForScripting = null;
            this.webView1.Title = null;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1670, 911);
            this.Controls.Add(this.webControl1);
            this.Name = "FormLogin";
            this.Text = "京东商智 登录";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormLogin_FormClosing);
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private EO.WinForm.WebControl webControl1;
        private EO.WebBrowser.WebView webView1;
    }
}

