namespace DianBaTaoBao
{
    partial class FormMain
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
            this.BtnLogin = new System.Windows.Forms.Button();
            this.BtnKeywords = new System.Windows.Forms.Button();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.openFileDialogKeywords = new System.Windows.Forms.OpenFileDialog();
            this.TxtKeywordsInfo = new System.Windows.Forms.TextBox();
            this.TxtTaobaoProgress = new System.Windows.Forms.TextBox();
            this.TxtDianbaProgress = new System.Windows.Forms.TextBox();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnContinue = new System.Windows.Forms.Button();
            this.BtnSaveData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnLogin
            // 
            this.BtnLogin.Location = new System.Drawing.Point(61, 341);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(136, 39);
            this.BtnLogin.TabIndex = 0;
            this.BtnLogin.Text = "登录";
            this.BtnLogin.UseVisualStyleBackColor = true;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // BtnKeywords
            // 
            this.BtnKeywords.Location = new System.Drawing.Point(61, 212);
            this.BtnKeywords.Name = "BtnKeywords";
            this.BtnKeywords.Size = new System.Drawing.Size(136, 49);
            this.BtnKeywords.TabIndex = 1;
            this.BtnKeywords.Text = "输入关键词";
            this.BtnKeywords.UseVisualStyleBackColor = true;
            this.BtnKeywords.Click += new System.EventHandler(this.BtnKeywords_Click);
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(61, 506);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(136, 47);
            this.BtnSearch.TabIndex = 2;
            this.BtnSearch.Text = "查询";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // openFileDialogKeywords
            // 
            this.openFileDialogKeywords.DefaultExt = "*.txt";
            this.openFileDialogKeywords.Filter = "文本文件|*.txt";
            this.openFileDialogKeywords.Multiselect = true;
            // 
            // TxtKeywordsInfo
            // 
            this.TxtKeywordsInfo.Location = new System.Drawing.Point(315, 12);
            this.TxtKeywordsInfo.Multiline = true;
            this.TxtKeywordsInfo.Name = "TxtKeywordsInfo";
            this.TxtKeywordsInfo.ReadOnly = true;
            this.TxtKeywordsInfo.Size = new System.Drawing.Size(1303, 440);
            this.TxtKeywordsInfo.TabIndex = 3;
            // 
            // TxtTaobaoProgress
            // 
            this.TxtTaobaoProgress.Location = new System.Drawing.Point(315, 506);
            this.TxtTaobaoProgress.Name = "TxtTaobaoProgress";
            this.TxtTaobaoProgress.ReadOnly = true;
            this.TxtTaobaoProgress.Size = new System.Drawing.Size(1303, 28);
            this.TxtTaobaoProgress.TabIndex = 4;
            // 
            // TxtDianbaProgress
            // 
            this.TxtDianbaProgress.Location = new System.Drawing.Point(315, 596);
            this.TxtDianbaProgress.Name = "TxtDianbaProgress";
            this.TxtDianbaProgress.ReadOnly = true;
            this.TxtDianbaProgress.Size = new System.Drawing.Size(1303, 28);
            this.TxtDianbaProgress.TabIndex = 5;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(61, 596);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(136, 41);
            this.BtnCancel.TabIndex = 6;
            this.BtnCancel.Text = "停止查询";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnContinue
            // 
            this.BtnContinue.Location = new System.Drawing.Point(61, 118);
            this.BtnContinue.Name = "BtnContinue";
            this.BtnContinue.Size = new System.Drawing.Size(136, 49);
            this.BtnContinue.TabIndex = 7;
            this.BtnContinue.Text = "读档";
            this.BtnContinue.UseVisualStyleBackColor = true;
            this.BtnContinue.Click += new System.EventHandler(this.BtnContinue_Click);
            // 
            // BtnSaveData
            // 
            this.BtnSaveData.Location = new System.Drawing.Point(61, 671);
            this.BtnSaveData.Name = "BtnSaveData";
            this.BtnSaveData.Size = new System.Drawing.Size(136, 49);
            this.BtnSaveData.TabIndex = 8;
            this.BtnSaveData.Text = "存档";
            this.BtnSaveData.UseVisualStyleBackColor = true;
            this.BtnSaveData.Click += new System.EventHandler(this.BtnSaveData_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1630, 742);
            this.Controls.Add(this.BtnSaveData);
            this.Controls.Add(this.BtnContinue);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.TxtDianbaProgress);
            this.Controls.Add(this.TxtTaobaoProgress);
            this.Controls.Add(this.TxtKeywordsInfo);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.BtnKeywords);
            this.Controls.Add(this.BtnLogin);
            this.Name = "FormMain";
            this.Text = "淘宝 电霸 V5";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnLogin;
        private System.Windows.Forms.Button BtnKeywords;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.OpenFileDialog openFileDialogKeywords;
        private System.Windows.Forms.TextBox TxtKeywordsInfo;
        private System.Windows.Forms.TextBox TxtTaobaoProgress;
        private System.Windows.Forms.TextBox TxtDianbaProgress;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnContinue;
        private System.Windows.Forms.Button BtnSaveData;
    }
}

