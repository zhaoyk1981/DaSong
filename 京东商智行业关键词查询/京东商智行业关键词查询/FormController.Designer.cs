namespace 京东商智行业关键词查询
{
    partial class FormController
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnLogin = new System.Windows.Forms.Button();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.BtnChooseFile = new System.Windows.Forms.Button();
            this.LblSelectedFile = new System.Windows.Forms.Label();
            this.OfdKeyWords = new System.Windows.Forms.OpenFileDialog();
            this.LblPercent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnLogin
            // 
            this.BtnLogin.Location = new System.Drawing.Point(83, 68);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(634, 58);
            this.BtnLogin.TabIndex = 0;
            this.BtnLogin.Text = "第一步：登录京东商智";
            this.BtnLogin.UseVisualStyleBackColor = true;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(83, 357);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(634, 50);
            this.BtnSearch.TabIndex = 1;
            this.BtnSearch.Text = "第三步：批量查询关键词";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // BtnChooseFile
            // 
            this.BtnChooseFile.Location = new System.Drawing.Point(83, 181);
            this.BtnChooseFile.Name = "BtnChooseFile";
            this.BtnChooseFile.Size = new System.Drawing.Size(634, 59);
            this.BtnChooseFile.TabIndex = 2;
            this.BtnChooseFile.Text = "第二步：选择CSV文件";
            this.BtnChooseFile.UseVisualStyleBackColor = true;
            this.BtnChooseFile.Click += new System.EventHandler(this.BtnChooseFile_Click);
            // 
            // LblSelectedFile
            // 
            this.LblSelectedFile.AutoSize = true;
            this.LblSelectedFile.Location = new System.Drawing.Point(80, 274);
            this.LblSelectedFile.Name = "LblSelectedFile";
            this.LblSelectedFile.Size = new System.Drawing.Size(134, 18);
            this.LblSelectedFile.TabIndex = 3;
            this.LblSelectedFile.Text = "您还未选择文件";
            // 
            // OfdKeyWords
            // 
            this.OfdKeyWords.Filter = "CSV 文件|*.csv";
            // 
            // LblPercent
            // 
            this.LblPercent.AutoSize = true;
            this.LblPercent.Location = new System.Drawing.Point(80, 459);
            this.LblPercent.Name = "LblPercent";
            this.LblPercent.Size = new System.Drawing.Size(0, 18);
            this.LblPercent.TabIndex = 4;
            // 
            // FormController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1874, 1255);
            this.Controls.Add(this.LblPercent);
            this.Controls.Add(this.LblSelectedFile);
            this.Controls.Add(this.BtnChooseFile);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.BtnLogin);
            this.Name = "FormController";
            this.Text = "FormController";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormController_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnLogin;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.Button BtnChooseFile;
        private System.Windows.Forms.Label LblSelectedFile;
        private System.Windows.Forms.OpenFileDialog OfdKeyWords;
        private System.Windows.Forms.Label LblPercent;
    }
}