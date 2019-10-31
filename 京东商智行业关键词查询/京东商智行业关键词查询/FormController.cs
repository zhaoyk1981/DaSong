using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 京东商智行业关键词查询
{
    public partial class FormController : Form
    {
        public FormController()
        {
            InitializeComponent();
        }

        private FormWebBrowser frmLogin { get; set; }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (frmLogin == null || frmLogin.IsDisposed)
            {
                frmLogin = new FormWebBrowser();
            }

            frmLogin.Show();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            var ext = Path.GetExtension(this.LblSelectedFile.Text).ToLower();
            IList<KeywordModel> list = null;
            switch (ext)
            {
                case ".csv":
                    list = this.ReadKeywordsFromCsv(this.LblSelectedFile.Text);
                    break;
                default:
                    MessageBox.Show("不支持此格式。");
                    return;
            }


            //frmLogin.WebView.LoadUrlAndWait("https://sz.jd.com/sz/api/industryKeyWord/getKeywordsSummData.ajax?channel=99&date=302019-10-28&endDate=2019-10-28&kw=%25E6%25B4%2597%25E6%2589%258B%25E6%25B6%25B2%2520%25E5%25A4%25A7%25E6%25A1%25B6&startDate=2019-09-29");
            //MessageBox.Show(frmLogin.WebView.GetText());
        }

        private void FormController_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (frmLogin != null)
            {
                frmLogin.Close();
            }
        }

        private void BtnChooseFile_Click(object sender, EventArgs e)
        {
            if (OfdKeyWords.ShowDialog() == DialogResult.OK)
            {
                this.LblSelectedFile.Text = OfdKeyWords.FileName;
            }
        }

        private IList<KeywordModel> ReadKeywordsFromCsv(string fileName)
        {
            var list = new List<KeywordModel>();
            foreach (var str in File.ReadAllLines(fileName, SimpleHelpers.FileEncoding.DetectFileEncoding(fileName, Encoding.Default))
                .Select(m => (m ?? string.Empty).Trim())
                .Where(m => !string.IsNullOrEmpty(m))
                .ToList())
            {
                var k = new KeywordModel();
                var items = str.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                k.Id = items.FirstOrDefault();
                k.Keyword = items.ElementAtOrDefault(1);
                k.DataList = items.Skip(2).ToList();
                list.Add(k);
            }

            return list;
        }

    }
}
