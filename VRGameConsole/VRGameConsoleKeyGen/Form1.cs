using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VRGameConsoleKeyGen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var biz = new ValidationBiz();
            this.txtKey.Text = biz.GenKey(txtCpuId.Text.Trim(), this.dateTimePicker1.Value.Date.ToUniversalTime().Ticks, this.dateTimePicker2.Value.Date.AddDays(1).ToUniversalTime().Ticks);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var biz = new ValidationBiz();
            this.txtCpuId.Text = biz.GetCpuId();
        }
    }
}
