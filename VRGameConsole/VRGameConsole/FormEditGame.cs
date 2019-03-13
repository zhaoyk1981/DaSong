using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VRGameConsole.Models;
using System.IO;
namespace VRGameConsole
{
    public partial class FormEditGame : Form
    {
        public FormEditGame()
        {
            InitializeComponent();
        }

        public string NewAppPath
        {
            get
            {
                return this.TxtPath.Text.Trim();
            }
            set
            {
                this.TxtPath.Text = value;
                this.ChooseGameDialog.InitialDirectory =
                    string.IsNullOrEmpty(value) ? string.Empty : Path.GetDirectoryName(value);
                this.AutoFillAppInfo();
            }
        }

        private void AutoFillAppInfo()
        {
            this.TxtName.Text = string.Empty;
            this.TxtProcessName.Text = string.Empty;
            this.TxtPath.Text = this.TxtPath.Text.Trim();
            if (!string.IsNullOrEmpty(this.TxtPath.Text))
            {
                this.TxtProcessName.Text = this.TxtName.Text = Path.GetFileNameWithoutExtension(this.TxtPath.Text);
            }
        }

        public FormMain FormMain { get; set; }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            var newApp = new AppModel()
            {
                Name = this.TxtName.Text.Trim(),
                Path = this.TxtPath.Text.Trim(),
                ProcessName = this.TxtProcessName.Text.Trim()
            };
            if (this.FormMain.Controller.Save(newApp))
            {
                this.FormMain.RefreshGamesList(newApp.Name);
                this.Close();
            }
            else
            {
                this.FormMain.RefreshGamesList();
                MessageBox.Show(this, "An error occurred while adding the program.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            if (this.ChooseGameDialog.ShowDialog() == DialogResult.OK)
            {
                this.TxtPath.Text = this.ChooseGameDialog.FileName;
                this.AutoFillAppInfo();
            }
        }
    }
}
