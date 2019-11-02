using Newtonsoft.Json;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
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
            this.BtnLogin.Enabled = this.BtnChooseFile.Enabled = this.BtnSearch.Enabled = false;
            Worker = new BackgroundWorker();
            Worker.WorkerSupportsCancellation = true;
            Worker.WorkerReportsProgress = true;
            Worker.DoWork += Worker_DoWork;
            Worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            Worker.ProgressChanged += Worker_ProgressChanged;
            Worker.RunWorkerAsync();
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.LblPercent.Text = e.UserState as string;
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.BtnLogin.Enabled = this.BtnChooseFile.Enabled = this.BtnSearch.Enabled = true;
            if (!e.Cancelled)
            {
                System.Diagnostics.Process.Start("Explorer", $"{Environment.CurrentDirectory}");
            }
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (var idxFileName = 0; idxFileName < this.OfdKeyWords.FileNames.Length; idxFileName++)
            {
                var csvFileName = this.OfdKeyWords.FileNames[idxFileName];
                this.Worker.ReportProgress(0, $"正在读取文件 {Path.GetFileName(csvFileName)}");
                var ext = Path.GetExtension(csvFileName).ToLower();
                IList<KeywordModel> list = null;
                switch (ext)
                {
                    case ".csv":
                        list = this.ReadKeywordsFromCsv(csvFileName);
                        break;
                    default:
                        MessageBox.Show("不支持此格式。");
                        e.Result = "";
                        return;
                }

                var dtNow = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                var dtMonthAgo = DateTime.Now.AddDays(-31).ToString("yyyy-MM-dd");
                var i = 0;
                foreach (var kw in list)
                {
                    if (Worker.CancellationPending)
                    {
                        e.Cancel = true;

                        break;
                    }

                    var url = $"https://sz.jd.com/sz/api/industryKeyWord/getKeywordsSummData.ajax?channel=99&date=30{dtNow}&endDate={dtNow}&kw={WebUtility.UrlEncode(kw.Keyword)}&startDate={dtMonthAgo}";
                    frmLogin.WebView.LoadUrlAndWait(url);
                    var strJson = frmLogin.WebView.GetText();
                    var resultObj = JsonConvert.DeserializeObject<ResultModel>(strJson);
                    if (resultObj.message == "success" || resultObj.message == "success：上期数据为空")
                    {
                        var c = 0;
                        if (!string.IsNullOrEmpty(resultObj.content.SearchClickIndex.value))
                        {
                            c++;
                            kw.搜索点击指数.Value = decimal.Parse(resultObj.content.SearchClickIndex.value, NumberStyles.Any);
                            kw.搜索点击指数.Rate = resultObj.content.SearchClickIndex.rate;
                        }

                        if (!string.IsNullOrEmpty(resultObj.content.SearchIndex.value))
                        {
                            c++;
                            kw.搜索指数.Value = decimal.Parse(resultObj.content.SearchIndex.value, NumberStyles.Any);
                            kw.搜索指数.Rate = resultObj.content.SearchIndex.rate;
                        }

                        if (!string.IsNullOrEmpty(resultObj.content.OrdAmtIndex.value))
                        {
                            c++;
                            kw.成交金额指数.Value = decimal.Parse(resultObj.content.OrdAmtIndex.value, NumberStyles.Any);
                            kw.成交金额指数.Rate = resultObj.content.OrdAmtIndex.rate;
                        }

                        if (!string.IsNullOrEmpty(resultObj.content.OrdNumIndex.value))
                        {
                            c++;
                            kw.成交单量指数.Value = decimal.Parse(resultObj.content.OrdNumIndex.value, NumberStyles.Any);
                            kw.成交单量指数.Rate = resultObj.content.OrdNumIndex.rate;
                        }

                        if (!string.IsNullOrEmpty(resultObj.content.ConvertRate.value))
                        {
                            c++;
                            kw.成交转化率.Value = decimal.Parse(resultObj.content.ConvertRate.value, NumberStyles.Any);
                            kw.成交转化率.Rate = resultObj.content.ConvertRate.rate;
                        }

                        if (!string.IsNullOrEmpty(resultObj.content.ClickRate.value))
                        {
                            c++;
                            kw.点击率.Value = decimal.Parse(resultObj.content.ClickRate.value, NumberStyles.Any);
                            kw.点击率.Rate = resultObj.content.ClickRate.rate;
                        }

                        if (!string.IsNullOrEmpty(resultObj.content.CommodityNumber.value))
                        {
                            c++;
                            kw.全网商品数.Value = decimal.Parse(resultObj.content.CommodityNumber.value, NumberStyles.Any);
                            kw.全网商品数.Rate = resultObj.content.CommodityNumber.rate;
                        }

                        if (!string.IsNullOrEmpty(resultObj.content.Competition.value))
                        {
                            c++;
                            kw.潜力值.Value = decimal.Parse(resultObj.content.Competition.value, NumberStyles.Any);
                            kw.潜力值.Rate = resultObj.content.Competition.rate;
                        }

                        kw.Valid = c > 0;
                    }

                    i++;
                    var percent = Convert.ToInt32((decimal)i / list.Count * 100);
                    Worker.ReportProgress(percent, $"文件：{idxFileName + 1}/{OfdKeyWords.FileNames.Length} {csvFileName}\r\n记录：{i}/{list.Count}");
                }

                if (e.Cancel)
                {
                    e.Result = null;
                    return;
                }

                //frmLogin.WebView.LoadUrlAndWait("https://sz.jd.com/sz/api/industryKeyWord/getKeywordsSummData.ajax?channel=99&date=302019-10-28&endDate=2019-10-28&kw=%25E6%25B4%2597%25E6%2589%258B%25E6%25B6%25B2%2520%25E5%25A4%25A7%25E6%25A1%25B6&startDate=2019-09-29");
                //MessageBox.Show(frmLogin.WebView.GetText());
                var fileName = $"{Path.GetFileNameWithoutExtension(csvFileName)}_{DateTime.Now.ToString("yyyyMMddHHmmss")}.xlsx";
                WriteExcel(list, fileName);
                Worker.ReportProgress(100, $"完成");
            }

            e.Result = string.Empty;
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
                this.LblSelectedFile.Text = string.Join("\r\n", OfdKeyWords.FileNames);
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

        private BackgroundWorker Worker { get; set; }

        private string ToIntText(decimal? val)
        {
            if (val.HasValue)
            {
                return val.Value.ToString("N0");
            }

            return "无";
        }

        private string ToRateText(decimal? val)
        {
            if (val.HasValue)
            {
                return (val.Value * 100).ToString("F2") + "%";
            }

            return "无";
        }

        public bool WriteExcel(IList<KeywordModel> dataSource, string file)
        {
            var allColumns = new List<string>() { "序号", "关键词", "搜索点击指数", "较前一期", "搜索指数", "较前一期", "成交金额指数", "较前一期", "成交单量指数", "较前一期", "成交转化率", "较前一期", "点击率", "较前一期", "全网商品数", "较前一期", "潜力值", "较前一期" };
            IWorkbook wk = new XSSFWorkbook();
            ISheet sheet = wk.CreateSheet("Sheet1");
            var rowIndex = 0;
            IRow headRow = sheet.CreateRow(rowIndex++);
            ICell cell;
            for (var i = 0; i < allColumns.Count; i++)
            {
                cell = headRow.CreateCell(i);
                cell.SetCellValue(allColumns[i]);
            }

            for (var i = 0; i < dataSource.Count; i++)
            {
                var data = dataSource[i];
                var rownum = i + 1;
                var row = sheet.CreateRow(rownum);
                var list = new List<string>()
                {
                    data.Id,
                    data.Keyword,
                    ToIntText(data.搜索点击指数.Value),
                    ToRateText(data.搜索点击指数.Rate),
                    ToIntText(data.搜索指数.Value),
                    ToRateText(data.搜索指数.Rate),
                    ToIntText(data.成交金额指数.Value),
                    ToRateText(data.成交金额指数.Rate),
                    ToIntText(data.成交单量指数.Value),
                    ToRateText(data.成交单量指数.Rate),
                    ToRateText(data.成交转化率.Value),
                    ToRateText(data.成交转化率.Rate),
                    ToRateText(data.点击率.Value),
                    ToRateText(data.点击率.Rate),
                    ToIntText(data.全网商品数.Value),
                    ToRateText(data.全网商品数.Rate),
                    ToIntText(data.潜力值.Value),
                    ToRateText(data.潜力值.Rate),
                };
                list.AddRange(data.DataList);

                for (var j = 0; j < list.Count; j++)
                {
                    cell = row.CreateCell(j);
                    cell.SetCellValue(list[j]);
                }
            }

            using (var stream = new FileStream(file, FileMode.Create, FileAccess.Write))
            {
                wk.Write(stream);
            }

            wk.Close();

            return true;
        }
    }
}
