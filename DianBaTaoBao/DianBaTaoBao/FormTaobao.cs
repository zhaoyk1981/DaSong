using EO.WebBrowser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DianBaTaoBao
{
    public partial class FormTaobao : Form
    {
        public FormTaobao()
        {
            InitializeComponent();
        }

        public FormMain FormMain { get; set; }

        public void RedirectTo(string url)
        {
            webView1.Url = url;
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
