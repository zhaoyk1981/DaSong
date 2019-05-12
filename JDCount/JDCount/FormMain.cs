using HtmlAgilityPack;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JDCount
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private AppContextModel Context { get; set; } = new AppContextModel();

        private BackgroundWorker Worker = new BackgroundWorker()
        {
            WorkerReportsProgress = true,
            WorkerSupportsCancellation = true
        };

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            if (this.TxtPath.ReadOnly)
            {
                return;
            }

            if (this.openXlsFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.TxtPath.ReadOnly = true;
                this.TxtPath.Text = this.openXlsFileDialog.FileName;
                this.Worker.RunWorkerAsync();
            }

            this.SetControls();
        }

        private void BtnGetCount_Click(object sender, EventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.SetControls();
            this.Worker.ProgressChanged += Worker_ProgressChanged;
            this.Worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            this.Worker.DoWork += Worker_DoWork;
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var result = this.ReadExcel(this.TxtPath.Text);
            if (!result)
            {
                MessageBox.Show($"解析Excel文件失败。");
                return;
            }

            this.GetCountFromJD();
            this.WriteExcel(this.TxtPath.Text);
            MessageBox.Show($"解析Excel文件成功。({this.Context.List.Count})");
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.TxtPath.ReadOnly = false;
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void SetControls()
        {
            //this.BtnGetCount.Enabled = !string.IsNullOrEmpty(this.TxtPath.Text);
        }

        private bool ReadExcel(string filePath)
        {
            try
            {
                IWorkbook wk = null;
                this.Context.CountColIndex = this.Context.KeywordColIndex = -1;
                using (FileStream fsRead = File.OpenRead(filePath))
                {
                    //获取后缀名
                    string extension = filePath.Substring(filePath.LastIndexOf(".")).ToString().ToLower();
                    //判断是否是excel文件
                    if (extension == ".xlsx" || extension == ".xls")
                    {
                        //判断excel的版本
                        if (extension == ".xlsx")
                        {
                            wk = new XSSFWorkbook(fsRead);
                        }
                        else
                        {
                            wk = new HSSFWorkbook(fsRead);
                        }
                    }
                }

                //获取第一个sheet
                ISheet sheet = wk.GetSheetAt(0);
                //获取第一行
                IRow headrow = sheet.GetRow(0);

                //创建列
                for (int i = headrow.FirstCellNum; i < headrow.Cells.Count; i++)
                {
                    switch (headrow.Cells[i].StringCellValue.Trim())
                    {
                        case "关键词":
                            {
                                this.Context.KeywordColIndex = i;
                                break;
                            }
                        case "商品数":
                            {
                                this.Context.CountColIndex = i;
                                break;
                            }
                    }

                    if (this.Context.CountColIndex >= 0 && this.Context.KeywordColIndex >= 0)
                    {
                        break;
                    }
                }

                if (this.Context.CountColIndex < 0 || this.Context.KeywordColIndex < 0)
                {
                    return false;
                }

                this.Context.List.Clear();
                //读取每行,从第二行起
                for (int r = 1; r <= sheet.LastRowNum; r++)
                {
                    IRow row = sheet.GetRow(r);
                    var model = new 商品Model();
                    model.Index = r;
                    model.Keyword = row.GetCell(this.Context.KeywordColIndex).StringCellValue;
                    this.Context.List.Add(model);
                }

                return this.Context.List.Count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void WriteExcel(string filePath)
        {
            IWorkbook wk = null;
            using (FileStream fsRead = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                //获取后缀名
                string extension = filePath.Substring(filePath.LastIndexOf(".")).ToString().ToLower();
                //判断是否是excel文件
                if (extension == ".xlsx" || extension == ".xls")
                {
                    //判断excel的版本
                    if (extension == ".xlsx")
                    {
                        wk = new XSSFWorkbook(fsRead);
                    }
                    else
                    {
                        wk = new HSSFWorkbook(fsRead);
                    }
                }
            }

            //获取第一个sheet
            ISheet sheet = wk.GetSheetAt(0);

            foreach (var model in this.Context.List)
            {
                var row = sheet.GetRow(model.Index);
                ICell cell = null;
                if (row.Cells.Count <= this.Context.CountColIndex)
                {
                    cell = row.CreateCell(this.Context.CountColIndex);
                }
                else
                {
                    cell = row.Cells[this.Context.CountColIndex];
                }

                cell.SetCellValue(model.JDCount.GetValueOrDefault());
            }

            using (var fsRead = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                wk.Write(fsRead);
                fsRead.Close();
            }
        }

        private void GetCountFromJD()
        {
            foreach (var prod in this.Context.List)
            {
                var url = $"https://search.jd.com/Search?keyword={prod.Keyword}&enc=utf-8&qrst=1&rt=1&stop=1&vt=2&wq=%E7%9D%AB%E6%AF%9B%E8%86%8F&stock=1&click=1{(this.Context.京东物流 ? "&wtype=1" : "")}";
                //var html = this.GetResponseContent(url);
                prod.JDCount = this.FindCount(url);
            }
        }

        private string GetResponseContent(string url)
        {
            var req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Method = "GET";
            using (WebResponse resp = req.GetResponse())
            {
                string html = new StreamReader(resp.GetResponseStream(), Encoding.Unicode).ReadToEnd();
                try
                {
                    req.GetResponse().Close();
                }
                catch (WebException ex)
                {
                    throw ex;
                }
                return html;
            }
        }

        private int? FindCount(string url)
        {
            try
            {
                HtmlWeb webClient = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc = webClient.Load(url);
                var jResCountNode = doc.DocumentNode.SelectSingleNode("//span[@id='J_resCount']");

                if (int.TryParse(jResCountNode.InnerText.Replace("+", ""), out int tmp))
                {
                    return tmp;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
