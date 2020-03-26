using DianBaTaoBao.Models;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DianBaTaoBao.Biz
{
    public class ExcelLogic
    {
        public void WriteToExcel(IDictionary<string, IList<ResultModel>> resultDict, string fileName)
        {
            IWorkbook wk = new XSSFWorkbook();
            foreach (var sheet in resultDict)
            {
                WriteSheet(sheet.Key, sheet.Value, wk);
            }

            using (var stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                wk.Write(stream);
            }

            wk.Close();
        }

        private void WriteSheet(string sheetName, IList<ResultModel> resultList, IWorkbook workbook)
        {
            ISheet sheet = workbook.CreateSheet(sheetName);
            var rowIndex = 0;
            foreach (var result in resultList)
            {
                WriteResult(result, sheet, ref rowIndex);
            }
        }

        private void WriteResult(ResultModel result, ISheet sheet, ref int rowIndex)
        {
            IRow row = sheet.CreateRow(rowIndex++);
            WriteKeyword(row, result.Keyword);
            WriteHeader(sheet.CreateRow(rowIndex++));
            var index = 0;
            foreach (var item in result.List)
            {
                item.Sn = index + 1;
                WriteResultItem(sheet.CreateRow(rowIndex++), item);
                index++;
            }

            WriteResultAvg(sheet.CreateRow(rowIndex++), result);
        }

        private void WriteKeyword(IRow row, string keyword)
        {
            var colIndex = 0;
            SetEmptyCell(row, ref colIndex);
            SetCellText(row, keyword, ref colIndex);
        }

        private void WriteHeader(IRow row)
        {
            var colIndex = 0;
            SetCellText(row, "序号", ref colIndex);
            SetCellText(row, "淘宝月销量", ref colIndex);
            SetCellText(row, "淘宝价格", ref colIndex);
            SetCellText(row, "", ref colIndex);
            SetCellText(row, "拼多多月销量", ref colIndex);
            SetCellText(row, "近一天销量", ref colIndex);
            SetCellText(row, "近一周销量", ref colIndex);
            SetCellText(row, "总销量", ref colIndex);
            SetCellText(row, "售价", ref colIndex);
            SetCellText(row, "差额", ref colIndex);
        }

        private void WriteResultItem(IRow row, ResultItemModel resultItem)
        {
            var colIndex = 0;
            SetCellContent(row, resultItem.Sn, ref colIndex);
            SetCellContent(row, resultItem.IntTaobao月销量, ref colIndex);
            SetCellContent(row, resultItem.DecTaobao单价, ref colIndex);
            SetEmptyCell(row, ref colIndex);
            SetCellContent(row, resultItem.IntDianba月销量, ref colIndex);
            SetCellContent(row, resultItem.IntDianba日销量, ref colIndex);
            SetCellContent(row, resultItem.IntDianba周销量, ref colIndex);
            SetCellContent(row, resultItem.IntDianba总销量, ref colIndex);
            SetCellContent(row, resultItem.MetaDianba单价, ref colIndex);
            SetCellContent(row, resultItem.月销量差额, ref colIndex);
        }

        private void WriteResultAvg(IRow row, ResultModel result)
        {
            var colIndex = 0;
            SetCellText(row, "平均", ref colIndex);
            SetCellContent(row, result.AvgTb月销量, ref colIndex);
            SetCellContent(row, result.AvgTb单价, ref colIndex);
            SetEmptyCell(row, ref colIndex);
            SetCellContent(row, result.AvgDb月销量, ref colIndex);
            SetCellContent(row, result.AvgDb日销量, ref colIndex);
            SetCellContent(row, result.AvgDb周销量, ref colIndex);
            SetCellContent(row, result.AvgDb总销量, ref colIndex);
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

        private void SetCellContent(IRow row, decimal? content, ref int colIndex)
        {
            if (content.HasValue)
            {
                row.CreateCell(colIndex++).SetCellValue(Convert.ToDouble(content.Value));
            }
            else
            {
                row.CreateCell(colIndex++).SetCellValue("N/A");
            }
        }

        private void SetCellContent(IRow row, string content, ref int colIndex)
        {
            SetCellText(row, string.IsNullOrWhiteSpace(content) ? "N/A" : content, ref colIndex);
        }

        private void SetEmptyCell(IRow row, ref int colIndex)
        {
            SetCellText(row, string.Empty, ref colIndex);
        }

        private void SetCellText(IRow row, string text, ref int colIndex)
        {
            row.CreateCell(colIndex++).SetCellValue(text);
        }
    }
}
