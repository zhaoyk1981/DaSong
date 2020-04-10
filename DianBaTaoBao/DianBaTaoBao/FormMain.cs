using DianBaTaoBao.Biz;
using DianBaTaoBao.Models;
using Newtonsoft.Json;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
            this.TxtSavedFileName.Text = SAVED_DATA_FILE_NAME;

            if (!Directory.Exists("C:\\ffehe"))
            {
                Directory.CreateDirectory("C:\\ffehe");
            }

            if (!Directory.Exists("C:\\ffehecache"))
            {
                Directory.CreateDirectory("C:\\ffehecache");
            }

            if (!Directory.Exists("SavedDataBackup"))
            {
                Directory.CreateDirectory("SavedDataBackup");
            }

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
            this.WorkerTaobao.WorkerSupportsCancellation = true;
            this.WorkerDianba.WorkerSupportsCancellation = true;
        }

        private void WorkerDianba_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.TxtDianbaProgress.Text = e.UserState as string;
        }

        private void WorkerTaobao_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.TxtTaobaoProgress.Text = e.UserState as string;
        }

        private int TopRows
        {
            get
            {
                return Math.Min(int.Parse(ConfigurationManager.AppSettings["Top"]), 20);
            }
        }

        private void WorkerDianba_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!WorkerTaobao.IsBusy)
            {
                Merge();
            }
        }

        private void WorkerTaobao_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!WorkerDianba.IsBusy)
            {
                Merge();
            }
        }

        private bool IsCompleted()
        {
            if (this.KeywordsDict.Count == 0 || TaobaoResult.Count == 0 || DianbaResult.Count == 0 || this.KeywordsDict.Count != TaobaoResult.Count || this.KeywordsDict.Count != DianbaResult.Count)
            {
                return false;
            }

            foreach (var kv in DianbaResult)
            {
                if (kv.Value.Any(m => !m.Completed) || kv.Value.Count != KeywordsDict[kv.Key].Count)
                {
                    return false;
                }
            }

            foreach (var kv in TaobaoResult)
            {
                if (kv.Value.Any(m => !m.Completed) || kv.Value.Count != KeywordsDict[kv.Key].Count)
                {
                    return false;
                }
            }

            return true;
        }

        private bool SaveData()
        {
            var isCompleted = IsCompleted();

            DeleteSavedData();
            var savedData = new SavedDataModel();
            savedData.KeywordsDict = this.KeywordsDict;
            savedData.TaobaoResult = this.TaobaoResult;
            savedData.DianbaResult = this.DianbaResult;
            var strJson = JsonConvert.SerializeObject(savedData);
            try
            {
                File.WriteAllText(SAVED_DATA_FILE_NAME, strJson, Encoding.UTF8);
                File.Copy(SAVED_DATA_FILE_NAME, Path.Combine("SavedDataBackup", DateTime.Now.ToString("yyyyMMdd HHmmss") + ".json"));
                if (!isCompleted)
                {
                    MessageBox.Show("中断或发生错误。请先关闭本程序，然后重新打开本程序点击'继续'按钮并'登录'，继续'查询'.");
                    return isCompleted;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"存档时发生错误，请尝试手动删除存档文件 {SAVED_DATA_FILE_NAME}");
                File.WriteAllText($"{ Guid.NewGuid() }.json", strJson, Encoding.UTF8);
            }

            return isCompleted;
        }

        private void Merge()
        {
            if (!SaveData())
            {
                // 当不完整时，不输出excel.
                if (this.Dianba查询 > 0)
                {
                    this.timerRetry.Enabled = true;
                    this.timerRetry.Start();
                }

                return;
            }

            foreach (var kf in TaobaoResult)
            {
                var kfDianba = DianbaResult[kf.Key];
                foreach (var k in kf.Value)
                {
                    var kd = kfDianba.Single(m => m.Keyword == k.Keyword);
                    kd.List = kd.List.OrderByDescending(m => m.IntDianba月销量.GetValueOrDefault()).ToList();
                    for (var i = 0; i < k.List.Count; i++)
                    {
                        if (kd.List.Count <= i)
                        {
                            break;
                        }

                        k.List[i].MetaDianba单价 = kd.List[i].MetaDianba单价;
                        k.List[i].MetaDianba周销量 = kd.List[i].MetaDianba周销量;
                        k.List[i].MetaDianba总销量 = kd.List[i].MetaDianba总销量;
                        k.List[i].MetaDianba日销量 = kd.List[i].MetaDianba日销量;
                        k.List[i].MetaDianba月销量 = kd.List[i].MetaDianba月销量;
                        k.List[i].MetaDianba商品Id = kd.List[i].MetaDianba商品Id;
                    }
                }
            }

            var fn = $"拼多多数据 {DateTime.Now.ToString("yyyyMMdd_HHmm")}.xlsx";
            new ExcelLogic().WriteToExcel(TaobaoResult, fn);
            System.Diagnostics.Process.Start("Explorer", $"/select,{Path.Combine(Environment.CurrentDirectory, fn)}");

            this.TxtKeywordsInfo.Text = "完成\r\n\r\n" + this.TxtKeywordsInfo.Text;
            this.KeywordsDict.Clear();
        }

        private void RemoveResult()
        {

        }

        private IDictionary<string, IList<ResultModel>> TaobaoResult { get; set; } = new Dictionary<string, IList<ResultModel>>();

        private IDictionary<string, IList<ResultModel>> DianbaResult { get; set; } = new Dictionary<string, IList<ResultModel>>();

        private void WorkerDianba_DoWork(object sender, DoWorkEventArgs e)
        {
            var me = sender as BackgroundWorker;
            try
            {
                var indexFile = 0;
                foreach (var keywordsFile in KeywordsDict)
                {
                    if (me.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }

                    IList<ResultModel> resultList = new List<ResultModel>();
                    if (DianbaResult.ContainsKey(keywordsFile.Key))
                    {
                        resultList = DianbaResult[keywordsFile.Key];
                    }
                    else
                    {
                        DianbaResult.Add(keywordsFile.Key, resultList);
                    }


                    var list = keywordsFile.Value.ToList();
                    var indexKeyword = 0;
                    foreach (var searchItem in list)
                    {
                        if (me.CancellationPending)
                        {
                            e.Cancel = true;
                            return;
                        }

                        var result = resultList.SingleOrDefault(m => m.Keyword == searchItem.Keyword);
                        if (result == null)
                        {
                            result = new ResultModel();
                            result.Keyword = searchItem.Keyword;
                            resultList.Add(result);
                        }

                        if (result.Completed)
                        {
                            indexKeyword++;
                            continue;
                        }


                        SeleniumHelper.Sleep(DianbaWait);
                        var txtSearch = SeleniumHelper.FindWebElement("input[name='search']");
                        txtSearch.Clear();
                        txtSearch.SendKeys(searchItem.Keyword);
                        SeleniumHelper.Sleep(1);
                        var btnSearch = SeleniumHelper.FindWebElement(".search-btn");
                        btnSearch.Click();
                        SeleniumHelper.Sleep(0.3);
                        SeleniumHelper.WaitWebElementHide("#loader");

                        #region 方案1
                        //var rows = SeleniumHelper.FindWebElements("#dash-add2 > tr");
                        //var index = 0;
                        //foreach (var row in rows)
                        //{
                        //    if (me.CancellationPending)
                        //    {
                        //        e.Cancel = true;
                        //        return;
                        //    }

                        //    me.ReportProgress(0, $"文件：{keywordsFile.Key} {indexFile + 1} / {KeywordsDict.Count} | 关键词: {searchItem.Keyword} {indexKeyword + 1} / {list.Count} | 行：{index + 1} / {rows.Count}");
                        //    var resultItem = new ResultItemModel();
                        //    result.List.Add(resultItem);

                        //    resultItem.MetaDianba日销量 = SeleniumHelper.FindWebElement(row, "td:nth-of-type(5) > span")?.Text?.Trim();
                        //    resultItem.MetaDianba周销量 = SeleniumHelper.FindWebElement(row, "td:nth-of-type(6)")?.Text?.Trim();
                        //    resultItem.MetaDianba月销量 = SeleniumHelper.FindWebElement(row, "td:nth-of-type(7)")?.Text?.Trim();
                        //    resultItem.MetaDianba总销量 = SeleniumHelper.FindWebElement(row, "td:nth-of-type(8)")?.Text?.Trim();
                        //    resultItem.MetaDianba单价 = SeleniumHelper.FindWebElement(row, "td:nth-of-type(9)")?.Text?.Trim();
                        //    index++;
                        //}
                        #endregion

                        #region 方案2
                        var cells3 = SeleniumHelper.FindWebElements("#dash-add2 > tr > td:nth-of-type(3)");
                        var cells5 = SeleniumHelper.FindWebElements("#dash-add2 > tr > td:nth-of-type(5) > span");
                        var cells6 = SeleniumHelper.FindWebElements("#dash-add2 > tr > td:nth-of-type(6)");
                        var cells7 = SeleniumHelper.FindWebElements("#dash-add2 > tr > td:nth-of-type(7)");
                        var cells8 = SeleniumHelper.FindWebElements("#dash-add2 > tr > td:nth-of-type(8)");
                        var cells9 = SeleniumHelper.FindWebElements("#dash-add2 > tr > td:nth-of-type(9)");
                        for (var index = 0; index < cells5.Count; index++)
                        {
                            me.ReportProgress(0, $"文件：{keywordsFile.Key} | {indexFile + 1} / {KeywordsDict.Count} | 关键词: {searchItem.Keyword} {indexKeyword + 1} / {list.Count} | 行：{index + 1} / {cells5.Count}");
                            var resultItem = result.List.ElementAtOrDefault(index);
                            if (resultItem == null)
                            {
                                resultItem = new ResultItemModel();
                                result.List.Add(resultItem);
                            }

                            if (resultItem.Completed)
                            {
                                continue;
                            }

                            var gid = cells3[index].Text?.Trim() ?? string.Empty;
                            var gidIndex = gid.LastIndexOf(商品Id);
                            resultItem.MetaDianba商品Id = string.Empty;
                            if (gidIndex >= 0 && gid.Length >= gidIndex + 商品Id.Length)
                            {
                                resultItem.MetaDianba商品Id = gid.Substring(gidIndex + 商品Id.Length);
                            }

                            resultItem.MetaDianba日销量 = cells5[index].Text?.Trim();
                            resultItem.MetaDianba周销量 = cells6[index].Text?.Trim();
                            resultItem.MetaDianba月销量 = cells7[index].Text?.Trim();
                            resultItem.MetaDianba总销量 = cells8[index].Text?.Trim();
                            resultItem.MetaDianba单价 = cells9[index].Text?.Trim();
                            resultItem.Completed = true;
                            resultItem.HasError = false;
                            this.Dianba查询 = 0;
                        }

                        while (result.List.Count < this.TopRows)
                        {
                            result.List.Add(new ResultItemModel()
                            {
                                HasError = false,
                                Completed = true
                            });
                        }

                        #endregion

                        indexKeyword++;
                    }

                    indexFile++;
                }

                me.ReportProgress(0, "已完成");
            }
            catch (Exception ex)
            {
                var message = SeleniumHelper.FindWebElement(".swal2-content > span");
                if (message != null)
                {
                    if (message.Text.IndexOf("账号访问异常") >= 0)
                    {
                        return;
                    }

                    if (message.Text.IndexOf("接口") >= 0)
                    {
                        var btnOk = SeleniumHelper.FindWebElement(".swal2-confirm");
                        if (btnOk != null)
                        {
                            btnOk.Click();
                            Dianba查询++;
                        }
                    }
                }
            }
        }

        private int Dianba查询 { get; set; }

        private const string 商品Id = "商品ID:";

        private IDictionary<string, IList<KeywordModel>> KeywordsDict { get; set; } = new Dictionary<string, IList<KeywordModel>>();

        private string CleanHtml(string source)
        {
            var s = source.IndexOf("<body ");
            var close = "</body>";
            var d = source.IndexOf(close);
            var r = source.Substring(s, d + close.Length - s);
            return r;
        }

        private string TaobaoQuery
        {
            get
            {
                return ConfigurationManager.AppSettings["TaobaoQuery"];
            }
        }

        private int TaobaoWait
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["TaobaoWait"]);
            }
        }

        private int DianbaWait
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["DianbaWait"]);
            }
        }

        private void WorkerTaobao_DoWork(object sender, DoWorkEventArgs e)
        {
            var me = sender as BackgroundWorker;
            try
            {
                var indexFile = 0;
                foreach (var keywordsFile in KeywordsDict)
                {
                    if (me.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }

                    IList<ResultModel> resultList = new List<ResultModel>();
                    if (TaobaoResult.ContainsKey(keywordsFile.Key))
                    {
                        resultList = TaobaoResult[keywordsFile.Key];
                    }
                    else
                    {
                        TaobaoResult.Add(keywordsFile.Key, resultList);
                    }

                    var list = keywordsFile.Value.ToList();
                    var indexKeyword = 0;
                    foreach (var searchItem in list)
                    {
                        if (me.CancellationPending)
                        {
                            e.Cancel = true;
                            return;
                        }

                        var result = resultList.SingleOrDefault(m => m.Keyword == searchItem.Keyword);
                        if (result == null)
                        {
                            result = new ResultModel();
                            result.Keyword = searchItem.Keyword;
                            resultList.Add(result);
                        }

                        if (!result.Completed)
                        {
                            System.Threading.Thread.Sleep(TaobaoWait * 1000);
                            this.FormTaobao.WebView.LoadUrlAndWait($"https://s.taobao.com/search?q={HttpUtility.UrlEncode(searchItem.Keyword)}{TaobaoQuery}");
                            var strHtml = this.FormTaobao.WebView.GetHtml();
                            strHtml = CleanHtml(strHtml);
                            var doc = new HtmlAgilityPack.HtmlDocument();
                            doc.LoadHtml(strHtml);
                            var nodes = doc.DocumentNode.SelectNodes("//div[@data-category='auctions']");
                            me.ReportProgress(0, $"文件：{keywordsFile.Key} | {indexFile + 1} / {KeywordsDict.Count} | 关键词: {searchItem.Keyword} {indexKeyword + 1} / {list.Count}");
                            if (nodes == null)
                            {
                                for (var n = 0; n < TopRows; n++)
                                {
                                    result.List.Add(new ResultItemModel()
                                    {
                                        HasError = false,
                                        Completed = true
                                    });
                                }

                                if (me.CancellationPending)
                                {
                                    e.Cancel = true;
                                    return;
                                }
                            }
                            else
                            {
                                var index = 0;
                                foreach (var node in nodes)
                                {
                                    var resultItem = result.List.ElementAtOrDefault(index);
                                    if (resultItem == null)
                                    {
                                        resultItem = new ResultItemModel();
                                        result.List.Add(resultItem);
                                    }

                                    if (resultItem.Completed)
                                    {
                                        index++;
                                        continue;
                                    }

                                    resultItem.MetaTaobao单价 = (node.SelectSingleNode("descendant::div[@class='price g_price g_price-highlight']/strong")?.InnerText ?? string.Empty).Trim();
                                    resultItem.MetaTaobao月销量 = (node.SelectSingleNode("descendant::div[@class='deal-cnt']")?.InnerText ?? string.Empty).Trim();
                                    resultItem.MetaTaobaoUrl = (node.SelectSingleNode("descendant::a[@class='J_ClickStat']").Attributes["href"]?.Value ?? string.Empty).Trim();
                                    if (resultItem.MetaTaobaoUrl.StartsWith("//"))
                                    {
                                        resultItem.MetaTaobaoUrl = "https:" + resultItem.MetaTaobaoUrl;
                                    }

                                    resultItem.Completed = true;
                                    resultItem.HasError = false;

                                    index++;
                                    if (index >= TopRows && TopRows > 0)
                                    {
                                        break;
                                    }
                                }
                            }
                        }

                        indexKeyword++;
                    }

                    indexFile++;
                }

                me.ReportProgress(0, "已完成");
            }
            catch (Exception ex)
            {

            }
        }

        private SeleniumHelper SeleniumHelper { get; set; } = new SeleniumHelper();

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            this.timerRetry.Enabled = false;
            this.timerRetry.Stop();
            this.FormTaobao.Visible = true;
            this.FormTaobao.RedirectTo("https://login.taobao.com/member/login.jhtml");
            SeleniumHelper.RedirectTo("http://pdd.dianba6.com/");
        }

        private BackgroundWorker WorkerTaobao { get; set; } = new BackgroundWorker();

        private BackgroundWorker WorkerDianba { get; set; } = new BackgroundWorker();

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.timerRetry.Enabled = false;
            this.timerRetry.Stop();
            this.SeleniumHelper.QuitDriver();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            this.timerRetry.Enabled = false;
            this.timerRetry.Stop();
            if (this.KeywordsDict.Count == 0)
            {
                MessageBox.Show("请选择关键词文件。");
                return;
            }

            this.WorkerTaobao.RunWorkerAsync();
            this.WorkerDianba.RunWorkerAsync();
        }

        private void BtnKeywords_Click(object sender, EventArgs e)
        {
            this.timerRetry.Enabled = false;
            this.timerRetry.Stop();
            try
            {
                if (this.openFileDialogKeywords.ShowDialog(this) == DialogResult.OK)
                {
                    var b = new StringBuilder();
                    var files = openFileDialogKeywords.FileNames;
                    this.KeywordsDict.Clear();
                    this.TaobaoResult.Clear();
                    this.DianbaResult.Clear();
                    foreach (var fn in files)
                    {
                        var keywords = File.ReadAllLines(fn, FileEncoding.DetectFileEncoding(fn, Encoding.Default))
                            .Where(m => !string.IsNullOrWhiteSpace(m) && !m.StartsWith("//"))
                            .Select(m => m.Trim())
                            .Distinct()
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
            this.timerRetry.Enabled = false;
            this.timerRetry.Stop();
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

        private const string SAVED_DATA_FILE_NAME = "SavedData.json";

        private void DeleteSavedData()
        {
            try
            {
                if (File.Exists(SAVED_DATA_FILE_NAME))
                {
                    File.Delete(SAVED_DATA_FILE_NAME);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void BtnContinue_Click(object sender, EventArgs e)
        {
            if (!File.Exists(SAVED_DATA_FILE_NAME))
            {
                MessageBox.Show("没有发现存档文件。");
                return;
            }

            try
            {
                var strJson = File.ReadAllText(SAVED_DATA_FILE_NAME, Encoding.UTF8);
                DeleteSavedData();
                var savedData = JsonConvert.DeserializeObject<SavedDataModel>(strJson);
                this.KeywordsDict = savedData.KeywordsDict;
                this.TaobaoResult = savedData.TaobaoResult;
                this.DianbaResult = savedData.DianbaResult;
                var b = new StringBuilder();
                b.AppendLine("存档读取成功！");
                foreach (var kv in KeywordsDict)
                {
                    b.AppendLine($"{kv.Key}: {kv.Value.Count}");
                }

                this.TxtKeywordsInfo.Text = b.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("存档文件损坏");
                return;
            }
        }

        private void BtnSaveData_Click(object sender, EventArgs e)
        {
            if (KeywordsDict.Count > 0 && TaobaoResult.Count > 0 && DianbaResult.Count > 0 && !WorkerTaobao.IsBusy && !WorkerDianba.IsBusy)
            {
                SaveData();
            }
        }

        private void timerRetry_Tick(object sender, EventArgs e)
        {
            var me = sender as Timer;
            if (this.Dianba查询 <= 3 && this.KeywordsDict.Count > 0 && !IsCompleted())
            {
                if (!this.WorkerDianba.IsBusy)
                {
                    this.WorkerDianba.RunWorkerAsync();
                }
            }

            me.Enabled = false;
        }
    }
}
