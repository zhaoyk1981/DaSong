using AutoSC.Controllers;
using AutoSC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoSC
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private AppContextModel Context { get; set; }

        private UIController UIController { get; set; }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.Context = new AppContextModel();
            this.UIController = new UIController(this.Context);
            this.UIController.BindDropDownList(this.DdlBrowser, 浏览器Enum.Chrome);
        }
    }
}
