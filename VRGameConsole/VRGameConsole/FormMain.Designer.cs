namespace VRGameConsole
{
    partial class FormMain
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
            this.BtnAddGame = new System.Windows.Forms.Button();
            this.ChooseGameDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // BtnAddGame
            // 
            this.BtnAddGame.Location = new System.Drawing.Point(43, 28);
            this.BtnAddGame.Name = "BtnAddGame";
            this.BtnAddGame.Size = new System.Drawing.Size(75, 23);
            this.BtnAddGame.TabIndex = 0;
            this.BtnAddGame.Text = "Add Game";
            this.BtnAddGame.UseVisualStyleBackColor = true;
            this.BtnAddGame.Click += new System.EventHandler(this.BtnAddGame_Click);
            // 
            // ChooseGameDialog
            // 
            this.ChooseGameDialog.FileName = "Choose Game";
            this.ChooseGameDialog.Filter = "Game Files|*.exe";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnAddGame);
            this.Name = "FormMain";
            this.Text = "VR Game Console";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnAddGame;
        private System.Windows.Forms.OpenFileDialog ChooseGameDialog;
    }
}

