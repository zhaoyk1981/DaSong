namespace VRGameConsole
{
    partial class FormValidation
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
            this.button3 = new System.Windows.Forms.Button();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.txtCpuId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1112, 698);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(193, 39);
            this.button3.TabIndex = 2;
            this.button3.Text = "Verify";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(18, 90);
            this.txtKey.Multiline = true;
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(1287, 581);
            this.txtKey.TabIndex = 3;
            // 
            // txtCpuId
            // 
            this.txtCpuId.Location = new System.Drawing.Point(18, 12);
            this.txtCpuId.Name = "txtCpuId";
            this.txtCpuId.ReadOnly = true;
            this.txtCpuId.Size = new System.Drawing.Size(773, 28);
            this.txtCpuId.TabIndex = 4;
            // 
            // FormValidation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1330, 783);
            this.Controls.Add(this.txtCpuId);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.button3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormValidation";
            this.Text = "Verify";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormValidation_FormClosed);
            this.Load += new System.EventHandler(this.FormValidation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.TextBox txtCpuId;
    }
}