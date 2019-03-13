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

namespace VRGameConsole
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private ViewModel Model { get; set; } = new ViewModel();

        private void BtnAddGame_Click(object sender, EventArgs e)
        {
            if (this.ChooseGameDialog.ShowDialog() == DialogResult.OK)
            {
                var fileName = this.ChooseGameDialog.FileName;
                var newAppForm = new FormNewGame();
                newAppForm.NewAppPath = fileName;
                newAppForm.ShowDialog(this);
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }
    }
}
