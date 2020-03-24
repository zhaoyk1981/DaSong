using DianBaTaoBao.Biz;
using DianBaTaoBao.Models;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml;

namespace DianBaTaoBao
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        public FormTaobao FormTaobao { get; set; }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.FormTaobao = new FormTaobao();
            this.FormTaobao.Visible = false;
            this.WorkerTaobao.DoWork += WorkerTaobao_DoWork;
            this.WorkerDianba.DoWork += WorkerDianba_DoWork;
            this.WorkerTaobao.RunWorkerCompleted += WorkerTaobao_RunWorkerCompleted;
            this.WorkerDianba.RunWorkerCompleted += WorkerDianba_RunWorkerCompleted;
            this.WorkerTaobao.WorkerReportsProgress = true;
            this.WorkerDianba.WorkerReportsProgress = true;
            this.WorkerTaobao.ProgressChanged += WorkerTaobao_ProgressChanged;
            this.WorkerDianba.ProgressChanged += WorkerDianba_ProgressChanged;
        }

        private void WorkerDianba_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.TxtDianbaProgress.Text = e.UserState as string;
        }

        private void WorkerTaobao_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.TxtTaobaoProgress.Text = e.UserState as string;
        }

        private void WorkerDianba_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                RemoveResult();
                return;
            }

            if (!WorkerTaobao.IsBusy)
            {
                Merge();
            }
        }

        private void WorkerTaobao_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                RemoveResult();
                return;
            }

            if (!WorkerDianba.IsBusy)
            {
                Merge();
            }
        }

        private void Merge()
        {

        }

        private void RemoveResult()
        {

        }

        private IDictionary<string, IList<ResultModel>> TaobaoResult { get; set; } = new Dictionary<string, IList<ResultModel>>();

        private IDictionary<string, IList<ResultModel>> DianbaResult { get; set; } = new Dictionary<string, IList<ResultModel>>();

        private void WorkerDianba_DoWork(object sender, DoWorkEventArgs e)
        {
            var me = sender as BackgroundWorker;
            DianbaResult.Clear();
            try
            {
                var indexFile = 0;
                foreach (var keywordsFile in KeywordsDict)
                {
                    if (me.CancellationPending)
                    {
                        return;
                    }

                    var resultList = new List<ResultModel>();
                    DianbaResult.Add(keywordsFile.Key, resultList);

                    var list = keywordsFile.Value.ToList();
                    var indexKeyword = 0;
                    foreach (var searchItem in list)
                    {
                        if (me.CancellationPending)
                        {
                            return;
                        }

                        var result = new ResultModel();
                        resultList.Add(result);

                        var txtSearch = SeleniumHelper.FindWebElement("input[name='search']");
                        txtSearch.Clear();
                        txtSearch.SendKeys(searchItem.Keyword);
                        SeleniumHelper.Sleep(1);
                        var btnSearch = SeleniumHelper.FindWebElement(".search-btn");
                        btnSearch.Click();
                        SeleniumHelper.Sleep(0.3);
                        SeleniumHelper.WaitWebElementHide("#loader");
                        var rows = SeleniumHelper.FindWebElements("#dash-add2 > tr");
                        var index = 0;
                        foreach (var row in rows)
                        {
                            if (me.CancellationPending)
                            {
                                return;
                            }

                            me.ReportProgress(0, $"文件：{keywordsFile.Key} {indexFile + 1} / {KeywordsDict.Count} | 关键词: {searchItem.Keyword} {indexKeyword + 1} / {list.Count} | 行：{index + 1} / {rows.Count}");
                            var resultItem = new ResultItemModel();
                            result.List.Add(resultItem);

                            resultItem.MetaDianba日销量 = SeleniumHelper.FindWebElement(row, "td:nth-of-type(5) > span")?.Text?.Trim();
                            resultItem.MetaDianba周销量 = SeleniumHelper.FindWebElement(row, "td:nth-of-type(6) > span")?.Text?.Trim();
                            resultItem.MetaDianba月销量 = SeleniumHelper.FindWebElement(row, "td:nth-of-type(7) > span")?.Text?.Trim();
                            resultItem.MetaDianba总销量 = SeleniumHelper.FindWebElement(row, "td:nth-of-type(8) > span")?.Text?.Trim();
                            resultItem.MetaDianba单价 = SeleniumHelper.FindWebElement(row, "td:nth-of-type(9) > span")?.Text?.Trim();
                            index++;
                        }

                        indexKeyword++;
                    }

                    indexFile++;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private IDictionary<string, IList<KeywordModel>> KeywordsDict { get; set; } = new Dictionary<string, IList<KeywordModel>>();

        private string CleanHtml(string source)
        {
            var s = source.IndexOf("<body ");
            var close = "</body>";
            var d = source.IndexOf(close);
            var r = source.Substring(s, d + close.Length - s);
            return r;
        }
        private void WorkerTaobao_DoWork(object sender, DoWorkEventArgs e)
        {
            var me = sender as BackgroundWorker;
            TaobaoResult.Clear();
            try
            {
                var indexFile = 0;
                foreach (var keywordsFile in KeywordsDict)
                {
                    if (me.CancellationPending)
                    {
                        return;
                    }

                    var resultList = new List<ResultModel>();
                    TaobaoResult.Add(keywordsFile.Key, resultList);

                    var list = keywordsFile.Value.ToList();
                    var indexKeyword = 0;
                    foreach (var searchItem in list)
                    {
                        if (me.CancellationPending)
                        {
                            return;
                        }

                        var result = new ResultModel();
                        resultList.Add(result);

                        this.FormTaobao.WebView.LoadUrlAndWait($"https://s.taobao.com/search?q={HttpUtility.UrlEncode(searchItem.Keyword)}&imgfile=&commend=all&search_type=item&sourceId=tb.index&ie=utf8&sort=sale-desc");
                        var strHtml = this.FormTaobao.WebView.GetHtml();
                        strHtml = CleanHtml(strHtml);
                        var doc = new HtmlAgilityPack.HtmlDocument();
                        doc.LoadHtml(strHtml);
                        var nodes = doc.DocumentNode.SelectNodes("//div[@data-category='auctions']");
                        foreach (var node in nodes)
                        {
                            if (me.CancellationPending)
                            {
                                return;
                            }

                            me.ReportProgress(0, $"文件：{keywordsFile.Key} {indexFile + 1} / {KeywordsDict.Count} | 关键词: {searchItem.Keyword} {indexKeyword + 1} / {list.Count}");
                            var resultItem = new ResultItemModel();
                            result.List.Add(resultItem);

                            resultItem.MetaTaobao单价 = (node.SelectSingleNode("descendant::div[@class='price g_price g_price-highlight']/strong")?.InnerText ?? string.Empty).Trim();
                            resultItem.MetaTaobao月销量 = (node.SelectSingleNode("descendant::div[@class='deal-cnt']")?.InnerText ?? string.Empty).Trim();
                        }

                        indexKeyword++;
                    }

                    indexFile++;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private SeleniumHelper SeleniumHelper { get; set; } = new SeleniumHelper();

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            this.FormTaobao.Visible = true;
            this.FormTaobao.RedirectTo("https://login.taobao.com/member/login.jhtml");
            SeleniumHelper.RedirectTo("http://pdd.dianba6.com/");
        }

        private BackgroundWorker WorkerTaobao { get; set; } = new BackgroundWorker();

        private BackgroundWorker WorkerDianba { get; set; } = new BackgroundWorker();

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.SeleniumHelper.QuitDriver();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            this.WorkerTaobao.RunWorkerAsync();
            this.WorkerDianba.RunWorkerAsync();
        }

        private void BtnKeywords_Click(object sender, EventArgs e)
        {
            this.KeywordsDict.Clear();
            try
            {
                if (this.openFileDialogKeywords.ShowDialog(this) == DialogResult.OK)
                {
                    var b = new StringBuilder();
                    var files = openFileDialogKeywords.FileNames;
                    foreach (var fn in files)
                    {
                        var keywords = File.ReadAllLines(fn, FileEncoding.DetectFileEncoding(fn, Encoding.Default))
                            .Where(m => !string.IsNullOrWhiteSpace(m) && !m.StartsWith("//"))
                            .Select(m => new KeywordModel() { Keyword = m })
                            .ToList();
                        var name = Path.GetFileNameWithoutExtension(fn);
                        if (keywords.Count > 0)
                        {
                            this.KeywordsDict.Add(name, keywords);
                        }

                        b.AppendLine($"{name}: {keywords.Count}");
                    }

                    this.TxtKeywordsInfo.Text = b.ToString();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (WorkerDianba.IsBusy || WorkerTaobao.IsBusy)
            {
                if (MessageBox.Show(this, "是否要停止查询？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (WorkerDianba.IsBusy)
                    {
                        WorkerDianba.CancelAsync();
                    }

                    if (WorkerTaobao.IsBusy)
                    {
                        WorkerTaobao.CancelAsync();
                    }
                }
            }
        }
    }
}
