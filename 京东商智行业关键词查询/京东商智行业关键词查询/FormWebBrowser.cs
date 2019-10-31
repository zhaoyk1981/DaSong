using EO.WebBrowser;
using EO.WinForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace 京东商智行业关键词查询
{
    public partial class FormWebBrowser : Form
    {
        public FormWebBrowser()
        {
            InitializeComponent();

        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            webView1.Url = "https://sz.jd.com/sz/view/index/login.html?ReturnUrl=http%3A%2F%2Fsz.jd.com%2Fsz%2Fview%2Findexs.html";
            
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        public WebView WebView
        {
            get
            {
                return this.webView1;
            }
        }
    }
}
