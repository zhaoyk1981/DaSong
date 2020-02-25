using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VRGameConsole
{
    public partial class FormValidation : Form
    {
        public FormValidation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var biz = new ValidationBiz();
            var str = biz.GetValidationData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var biz = new ValidationBiz();
            biz.Create("");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var biz = new ValidationBiz();
            biz.Create(txtKey.Text.Trim());
            if (biz.Validate(true))
            {
                this.IsValid = true;
                this.FormMain.SetRunGameVisible();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        public FormMain FormMain { get; set; }

        private bool IsValid { get; set; }

        private void FormValidation_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!IsValid)
            {
                Application.Exit();
            }
        }

        private void FormValidation_Load(object sender, EventArgs e)
        {
            var biz = new ValidationBiz();
            this.txtCpuId.Text = biz.GetCpuId();
            this.IsValid = biz.Validate(false);
        }
    }
}
