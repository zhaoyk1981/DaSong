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
            this.TxtDesc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnAddGame
            // 
            this.BtnAddGame.Location = new System.Drawing.Point(664, 103);
            this.BtnAddGame.Margin = new System.Windows.Forms.Padding(4);
            this.BtnAddGame.Name = "BtnAddGame";
            this.BtnAddGame.Size = new System.Drawing.Size(155, 34);
            this.BtnAddGame.TabIndex = 30;
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
            this.ListGames.Location = new System.Drawing.Point(48, 103);
            this.ListGames.Name = "ListGames";
            this.ListGames.ScrollAlwaysVisible = true;
            this.ListGames.Size = new System.Drawing.Size(581, 220);
            this.ListGames.TabIndex = 20;
            // 
            // BtnRemoveGame
            // 
            this.BtnRemoveGame.Location = new System.Drawing.Point(664, 168);
            this.BtnRemoveGame.Name = "BtnRemoveGame";
            this.BtnRemoveGame.Size = new System.Drawing.Size(155, 36);
            this.BtnRemoveGame.TabIndex = 40;
            this.BtnRemoveGame.Text = "Remove Game";
            this.BtnRemoveGame.UseVisualStyleBackColor = true;
            this.BtnRemoveGame.Click += new System.EventHandler(this.BtnRemoveGame_Click);
            // 
            // BtnRunGame
            // 
            this.BtnRunGame.Location = new System.Drawing.Point(474, 344);
            this.BtnRunGame.Name = "BtnRunGame";
            this.BtnRunGame.Size = new System.Drawing.Size(155, 36);
            this.BtnRunGame.TabIndex = 60;
            this.BtnRunGame.Text = "Run";
            this.BtnRunGame.UseVisualStyleBackColor = true;
            this.BtnRunGame.Click += new System.EventHandler(this.BtnRunGame_Click);
            // 
            // ComboBoxLimitTime
            // 
            this.ComboBoxLimitTime.FormattingEnabled = true;
            this.ComboBoxLimitTime.Location = new System.Drawing.Point(152, 350);
            this.ComboBoxLimitTime.Name = "ComboBoxLimitTime";
            this.ComboBoxLimitTime.Size = new System.Drawing.Size(166, 26);
            this.ComboBoxLimitTime.TabIndex = 50;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 353);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Time (minute):";
            // 
            // TxtDesc
            // 
            this.TxtDesc.Location = new System.Drawing.Point(48, 30);
            this.TxtDesc.Name = "TxtDesc";
            this.TxtDesc.Size = new System.Drawing.Size(581, 28);
            this.TxtDesc.TabIndex = 10;
            this.TxtDesc.TextChanged += new System.EventHandler(this.TxtDesc_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Description:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "Game List:";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(833, 398);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtDesc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ComboBoxLimitTime);
            this.Controls.Add(this.BtnRunGame);
            this.Controls.Add(this.BtnRemoveGame);
            this.Controls.Add(this.ListGames);
            this.Controls.Add(this.BtnAddGame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VR Game Console";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
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
        private System.Windows.Forms.TextBox TxtDesc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

