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
            this.ListGames = new System.Windows.Forms.ListBox();
            this.BtnRemoveGame = new System.Windows.Forms.Button();
            this.BtnRunGame = new System.Windows.Forms.Button();
            this.ComboBoxLimitTime = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnAddGame
            // 
            this.BtnAddGame.Location = new System.Drawing.Point(786, 46);
            this.BtnAddGame.Margin = new System.Windows.Forms.Padding(4);
            this.BtnAddGame.Name = "BtnAddGame";
            this.BtnAddGame.Size = new System.Drawing.Size(155, 34);
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
            // ListGames
            // 
            this.ListGames.FormattingEnabled = true;
            this.ListGames.ItemHeight = 18;
            this.ListGames.Location = new System.Drawing.Point(126, 36);
            this.ListGames.Name = "ListGames";
            this.ListGames.ScrollAlwaysVisible = true;
            this.ListGames.Size = new System.Drawing.Size(581, 220);
            this.ListGames.TabIndex = 1;
            // 
            // BtnRemoveGame
            // 
            this.BtnRemoveGame.Location = new System.Drawing.Point(786, 114);
            this.BtnRemoveGame.Name = "BtnRemoveGame";
            this.BtnRemoveGame.Size = new System.Drawing.Size(155, 36);
            this.BtnRemoveGame.TabIndex = 2;
            this.BtnRemoveGame.Text = "Remove Game";
            this.BtnRemoveGame.UseVisualStyleBackColor = true;
            this.BtnRemoveGame.Click += new System.EventHandler(this.BtnRemoveGame_Click);
            // 
            // BtnRunGame
            // 
            this.BtnRunGame.Location = new System.Drawing.Point(552, 292);
            this.BtnRunGame.Name = "BtnRunGame";
            this.BtnRunGame.Size = new System.Drawing.Size(155, 36);
            this.BtnRunGame.TabIndex = 3;
            this.BtnRunGame.Text = "Run";
            this.BtnRunGame.UseVisualStyleBackColor = true;
            this.BtnRunGame.Click += new System.EventHandler(this.BtnRunGame_Click);
            // 
            // ComboBoxLimitTime
            // 
            this.ComboBoxLimitTime.FormattingEnabled = true;
            this.ComboBoxLimitTime.Location = new System.Drawing.Point(319, 298);
            this.ComboBoxLimitTime.Name = "ComboBoxLimitTime";
            this.ComboBoxLimitTime.Size = new System.Drawing.Size(121, 26);
            this.ComboBoxLimitTime.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 301);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Running time (minute):";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1200, 675);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ComboBoxLimitTime);
            this.Controls.Add(this.BtnRunGame);
            this.Controls.Add(this.BtnRemoveGame);
            this.Controls.Add(this.ListGames);
            this.Controls.Add(this.BtnAddGame);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.Text = "VR Game Console";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnAddGame;
        private System.Windows.Forms.OpenFileDialog ChooseGameDialog;
        private System.Windows.Forms.ListBox ListGames;
        private System.Windows.Forms.Button BtnRemoveGame;
        private System.Windows.Forms.Button BtnRunGame;
        private System.Windows.Forms.ComboBox ComboBoxLimitTime;
        private System.Windows.Forms.Label label1;
    }
}

