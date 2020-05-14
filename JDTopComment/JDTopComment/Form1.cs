using Newtonsoft.Json;
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
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace JDTopComment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    GetSearchResultBy("连衣裙");
        //}

        private const string RESULT_COUNT = "result_count";

        private JDSearchResultModel GetSearchResultBy(string keyword)
        {
            while (true)
            {
                try
                {
                    return _GetSearchResultBy(keyword);
                }
                catch (Exception ex)
                {
                    _useProxy2 = !_useProxy2;

                    if (ProxyList.Count > 0)
                    {
                        var p = ProxyList.FirstOrDefault(m => m.IsUsing);
                        if (p != null)
                        {
                            ProxyList.Remove(p);

                        }
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(20000);
                    }
                }
            }
        }

        private HttpClient GetHttpClient()
        {
            if (ProxyList.Count == 0 || !_useProxy || !_useProxy2)
            {
                return new HttpClient();
            }

            var p = ProxyList.FirstOrDefault(m => m.IsUsing);
            if (p == null)
            {
                p = ProxyList.ElementAt(Math.Abs(Convert.ToInt32(Guid.NewGuid().ToString().Substring(0, 8), 16)) % ProxyList.Count);
                p.IsUsing = true;
            }

            WebProxy proxy = new WebProxy(p.Url, false)
            {
                UseDefaultCredentials = true
            };
            HttpClientHandler httpClientHandler = new HttpClientHandler()
            {
                Proxy = proxy,
                PreAuthenticate = true,
                UseDefaultCredentials = true,
            };

            return new HttpClient(httpClientHandler);
        }

        private IList<ProxyAddrModel> ProxyList = new List<ProxyAddrModel>();

        private void InitProxyAddress()
        {
            ProxyList.Clear();
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36");
            try
            {
                var respStr = client.GetStringAsync($"https://www.xicidaili.com/nt/").Result;
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(respStr);
                var rows = doc.DocumentNode.SelectNodes("//tr").ToList();
                for (var i = 1; i < rows.Count; i++)
                {
                    var row = rows[i];
                    var type = row.SelectSingleNode("td[position()=6]").InnerText;
                    if (string.Compare(type, "http", true) != 0)
                    {
                        continue;
                    }

                    var p = new ProxyAddrModel()
                    {
                        IpAddr = row.SelectSingleNode("td[position()=2]").InnerText,
                        Port = row.SelectSingleNode("td[position()=3]").InnerText
                    };

                    if (!ProxyList.Any(m => m.Url == p.Url))
                    {
                        ProxyList.Add(p);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private JDSearchResultModel _GetSearchResultBy(string keyword)
        {
            var result = new JDSearchResultModel()
            {
                Keyword = keyword
            };
            var encodedKeyword = HttpUtility.UrlEncode(keyword);
            var client = GetHttpClient();
            client.Timeout = TimeSpan.FromSeconds(10);
            client.DefaultRequestHeaders.Add("authority", "search.jd.com");
            client.DefaultRequestHeaders.Referrer = new Uri($"https://search.jd.com/Search?keyword={encodedKeyword}&enc=utf-8&qrst=1&rt=1&stop=1&vt=2&psort=3&wtype=1&click=2");
            client.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.139 Safari/537.36");
            client.DefaultRequestHeaders.Add("x-requested-with", "XMLHttpRequest");

            try
            {
                var respStr = client.GetStringAsync($"https://search.jd.com/Search?keyword={encodedKeyword}&enc=utf-8&stop=1&qrst=1&psort=3&vt=2&psort=3&shop=1&click=2").Result;
                if (respStr.IndexOf(RESULT_COUNT) >= 0)
                {
                    result.ResultCount = GetResultCount(respStr);
                    if (result.ResultCount.GetValueOrDefault() == 0)
                    {
                        return result;
                    }

                    var doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(respStr);
                    var glItems = doc.DocumentNode.SelectNodes("//li[@class='gl-item']");

                    var i = 0;
                    foreach (var glItem in glItems)
                    {
                        if (i >= 5)
                        {
                            break;
                        }

                        var sku = glItem.Attributes["data-sku"].Value;
                        if (!result.ItemList.ContainsKey(sku))
                        {
                            result.ItemList.Add(sku, 0);
                            i++;
                        }
                    }

                    FillCommentsCount(result, client);
                }
                else
                {
                    //System.Threading.Thread.Sleep(15000);

                    throw new Exception("login");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        private void FillCommentsCount(JDSearchResultModel result, HttpClient httpClient)
        {
            if (result.ItemList.Count == 0)
            {
                return;
            }

            var refId = string.Join(",", result.ItemList.Keys);
            var jsonStr = httpClient.GetStringAsync($"https://club.jd.com/comment/productCommentSummaries.action?referenceIds={refId}").Result;
            var commentSummary = JsonConvert.DeserializeObject<ProductCommentSummaryModel>(jsonStr);
            foreach (var p in commentSummary.CommentsCount)
            {
                if (result.ItemList.ContainsKey(p.SkuId))
                {
                    result.ItemList[p.SkuId] = p.CommentCount;
                }
            }
        }

        private int? GetResultCount(string respStr)
        {
            var idxStart = respStr.IndexOf(RESULT_COUNT);
            if (idxStart < 0)
            {
                return null;
            }

            idxStart = respStr.IndexOf('\'', idxStart);
            if (idxStart < 0)
            {
                return null;
            }

            var idxEnd = respStr.IndexOf('\'', idxStart + 1);
            if (idxEnd < 0)
            {
                return null;
            }

            var strResultCount = respStr.Substring(idxStart + 1, idxEnd - idxStart - 1);
            if (int.TryParse(strResultCount, out int cnt))
            {
                return cnt;
            }

            return null;
        }

        private BackgroundWorker Worker = new BackgroundWorker();

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            if (Worker.IsBusy)
            {
                if (!Worker.CancellationPending)
                {
                    Worker.CancelAsync();
                }

                return;
            }

            if (this.openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                var fileNames = this.openFileDialog1.FileNames.ToList() as IList<string>;
                this.Worker.RunWorkerAsync(fileNames);
                this.LblProcess.Text = string.Empty;
                this.BtnBrowse.Text = "取消";
            }
        }

        private void Export(string file, IList<JDSearchResultModel> resultList)
        {
            var fullPath = Path.Combine(Environment.CurrentDirectory, "exports");
            var fileName = Path.Combine(fullPath, $"{Path.GetFileNameWithoutExtension(file)}_{DateTime.Now.ToString("yyyyMMdd HHmmss")}.xlsx");
            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }

            IWorkbook wk = new XSSFWorkbook();
            WriteSheet(Path.GetFileNameWithoutExtension(file), resultList, wk);

            using (var stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                wk.Write(stream);
            }

            wk.Close();
        }


        private void WriteSheet(string sheetName, IList<JDSearchResultModel> resultList, IWorkbook workbook)
        {
            ISheet sheet = workbook.CreateSheet(sheetName);
            var rowIndex = 0;
            IRow row = sheet.CreateRow(rowIndex++);
            WriteHeader(row);
            foreach (var result in resultList)
            {
                int colIndex = 0;
                row = sheet.CreateRow(rowIndex);
                SetCellContent(row, rowIndex, ref colIndex);
                SetCellText(row, result.Keyword, ref colIndex);
                SetCellContent(row, result.ResultCount, ref colIndex);
                foreach (var item in result.ItemList)
                {
                    SetCellContent(row, item.Value, ref colIndex);
                }

                rowIndex++;
            }
        }


        private void WriteHeader(IRow row)
        {
            var colIndex = 0;
            SetCellText(row, "序号", ref colIndex);
            SetCellText(row, "关键词", ref colIndex);
            SetCellText(row, "京东物流商品数", ref colIndex);
            SetCellText(row, "Top1 评价数", ref colIndex);
            SetCellText(row, "Top2 评价数", ref colIndex);
            SetCellText(row, "Top3 评价数", ref colIndex);
            SetCellText(row, "Top4 评价数", ref colIndex);
            SetCellText(row, "Top5 评价数", ref colIndex);
        }

        private void SetCellContent(IRow row, int? content, ref int colIndex)
        {
            if (content.HasValue)
            {
                row.CreateCell(colIndex++).SetCellValue(content.Value);
            }
            else
            {
                row.CreateCell(colIndex++).SetCellValue("N/A");
            }
        }

        private void SetCellText(IRow row, string text, ref int colIndex)
        {
            row.CreateCell(colIndex++).SetCellValue(text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Worker.WorkerSupportsCancellation = true;
            this.Worker.WorkerReportsProgress = true;
            this.Worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            this.Worker.DoWork += Worker_DoWork;
            this.Worker.ProgressChanged += Worker_ProgressChanged;
            InitProxyAddress();
        }
        private bool _useProxy;

        private bool _useProxy2;
        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.LblProcess.Text = e.UserState as string;
            this._useProxy = this.ChkUseProxy.Checked;
        }

        private IList<JDSearchResultModel> resultList { get; set; } = new List<JDSearchResultModel>();

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var fileNames = e.Argument as IList<string>;
            var fileIndex = 0;
            foreach (var file in fileNames)
            {
                var keywordList = File.ReadAllLines(file, FileEncoding.DetectFileEncoding(file, Encoding.Default)).Where(m => !string.IsNullOrEmpty(m) && !m.StartsWith("//")).ToList();

                var keywordIndex = 0;
                foreach (var k in keywordList)
                {
                    if (Worker.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }

                    var result = GetSearchResultBy(k);
                    resultList.Add(result);
                    Worker.ReportProgress(0, $"文件: {fileIndex + 1} / {fileNames.Count}, 关键词: {keywordIndex + 1} / {keywordList.Count}, {k}");
                    keywordIndex++;
                }

                Export(file, resultList);
                fileIndex++;
            }
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.BtnBrowse.Text = "浏览";
            MessageBox.Show(this, e.Cancelled ? "已取消" : "已完成");
        }
    }
}
