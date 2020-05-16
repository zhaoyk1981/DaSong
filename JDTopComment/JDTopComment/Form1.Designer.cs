namespace JDTopComment
{
    partial class Form1
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
            this.BtnBrowse = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.LblProcess = new System.Windows.Forms.Label();
            this.ChkUseProxy = new System.Windows.Forms.CheckBox();
            this.NumMaxLen = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtExclude = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.NumMaxLen)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnBrowse
            // 
            this.BtnBrowse.Location = new System.Drawing.Point(82, 55);
            this.BtnBrowse.Name = "BtnBrowse";
            this.BtnBrowse.Size = new System.Drawing.Size(127, 40);
            this.BtnBrowse.TabIndex = 1;
            this.BtnBrowse.Text = "浏览";
            this.BtnBrowse.UseVisualStyleBackColor = true;
            this.BtnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Txt|*.txt";
            this.openFileDialog1.Multiselect = true;
            // 
            // LblProcess
            // 
            this.LblProcess.AutoSize = true;
            this.LblProcess.Location = new System.Drawing.Point(94, 138);
            this.LblProcess.Name = "LblProcess";
            this.LblProcess.Size = new System.Drawing.Size(0, 18);
            this.LblProcess.TabIndex = 2;
            // 
            // ChkUseProxy
            // 
            this.ChkUseProxy.AutoSize = true;
            this.ChkUseProxy.Location = new System.Drawing.Point(305, 73);
            this.ChkUseProxy.Name = "ChkUseProxy";
            this.ChkUseProxy.Size = new System.Drawing.Size(106, 22);
            this.ChkUseProxy.TabIndex = 3;
            this.ChkUseProxy.Text = "使用代理";
            this.ChkUseProxy.UseVisualStyleBackColor = true;
            // 
            // NumMaxLen
            // 
            this.NumMaxLen.Location = new System.Drawing.Point(857, 55);
            this.NumMaxLen.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NumMaxLen.Name = "NumMaxLen";
            this.NumMaxLen.Size = new System.Drawing.Size(120, 28);
            this.NumMaxLen.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(728, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "最大长度：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(728, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "不包含：";
            // 
            // TxtExclude
            // 
            this.TxtExclude.Location = new System.Drawing.Point(857, 123);
            this.TxtExclude.Multiline = true;
            this.TxtExclude.Name = "TxtExclude";
            this.TxtExclude.Size = new System.Drawing.Size(324, 456);
            this.TxtExclude.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1480, 852);
            this.Controls.Add(this.TxtExclude);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NumMaxLen);
            this.Controls.Add(this.ChkUseProxy);
            this.Controls.Add(this.LblProcess);
            this.Controls.Add(this.BtnBrowse);
            this.Name = "Form1";
            this.Text = "京东 销量 评价数 抓取 v6";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumMaxLen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label LblProcess;
        private System.Windows.Forms.CheckBox ChkUseProxy;
        private System.Windows.Forms.NumericUpDown NumMaxLen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtExclude;
    }
}

