using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DaSongERP.Models;
using NPOI;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace DaSongERP.Dal
{
    public class ExcelDao : Dao
    {
        #region 导入电话客服

        public IList<OrderModel> ReadExcel电话客服(Stream excelStream, bool isXlsx)
        {
            excelStream.Position = 0;
            IList<OrderModel> orders = new List<OrderModel>();
            IWorkbook wk = null;
            if (isXlsx)
            {
                wk = new XSSFWorkbook(excelStream);
            }
            else
            {
                wk = new HSSFWorkbook(excelStream);
            }

            //获取第一个sheet
            ISheet sheet = wk.GetSheetAt(0);
            //获取第一行
            IRow headRow = sheet.GetRow(0);

            var dictColumns = new Dictionary<string, int>();
            foreach (var cell in headRow.Cells)
            {
                var colName = (cell.StringCellValue ?? string.Empty).Trim();
                if (string.IsNullOrEmpty(colName) || dictColumns.ContainsKey(colName))
                {
                    continue;
                }

                dictColumns.Add(colName, cell.ColumnIndex);
            }

            OrderModel lastOrder = null;
            for (var rowIndex = 1; rowIndex < sheet.PhysicalNumberOfRows; rowIndex++)
            {
                var row = sheet.GetRow(rowIndex);
                if (row == null)
                {
                    continue;
                }

                var o = new OrderModel();
                o.电话备注 = GetStringValue(lastOrder?.电话备注, row, dictColumns, "电话备注");
                o.JD订单号 = GetStringValue(lastOrder?.JD订单号, row, dictColumns, "销售平台单号");
                o.客人姓名 = GetStringValue(lastOrder?.客人姓名, row, dictColumns, "收件人");
                o.客人电话 = GetStringValue(lastOrder?.客人电话, row, dictColumns, "电话");
                o.客人地址 = GetStringValue(lastOrder?.客人地址, row, dictColumns, "地址");
                o.RowIndex = rowIndex;

                if (string.IsNullOrEmpty(o.JD订单号))
                {
                    lastOrder = null;
                    continue;
                }

                orders.Add(o);
                lastOrder = o;
            }

            wk.Close();

            return orders;
        }

        #endregion 导入电话客服

        #region 导入拆包审单

        public IList<OrderModel> ReadExcel拆包审单(Stream excelStream, bool isXlsx)
        {
            excelStream.Position = 0;
            IList<OrderModel> orders = new List<OrderModel>();
            IWorkbook wk = null;
            if (isXlsx)
            {
                wk = new XSSFWorkbook(excelStream);
            }
            else
            {
                wk = new HSSFWorkbook(excelStream);
            }

            //获取第一个sheet
            ISheet sheet = wk.GetSheetAt(0);
            //获取第一行
            IRow headRow = sheet.GetRow(0);

            var dictColumns = new Dictionary<string, int>();
            foreach (var cell in headRow.Cells)
            {
                var colName = (cell.StringCellValue ?? string.Empty).Trim();
                if (string.IsNullOrEmpty(colName) || dictColumns.ContainsKey(colName))
                {
                    continue;
                }

                dictColumns.Add(colName, cell.ColumnIndex);
            }

            for (var rowIndex = 1; rowIndex < sheet.PhysicalNumberOfRows; rowIndex++)
            {
                var row = sheet.GetRow(rowIndex);
                if (row == null)
                {
                    continue;
                }

                var o = new OrderModel();
                o.JD订单号 = GetStringValue(null, row, dictColumns, "订单号");
                o.来快递单号 = GetStringValue(null, row, dictColumns, "运单号");
                o.RowIndex = rowIndex;

                if (string.IsNullOrEmpty(o.JD订单号))
                {
                    continue;
                }

                if (string.IsNullOrEmpty(o.来快递单号))
                {
                    continue;
                }

                orders.Add(o);
            }

            wk.Close();

            return orders;
        }

        #endregion 导入拆包审单

        #region 导入采购订单

        public IList<OrderModel> ReadExcel采购订单(Stream excelStream, bool isXlsx)
        {
            excelStream.Position = 0;
            IList<OrderModel> orders = new List<OrderModel>();
            IWorkbook wk = null;
            if (isXlsx)
            {
                wk = new XSSFWorkbook(excelStream);
            }
            else
            {
                wk = new HSSFWorkbook(excelStream);
            }

            //获取第一个sheet
            ISheet sheet = wk.GetSheetAt(0);
            //获取第一行
            IRow headRow = sheet.GetRow(0);

            var dictColumns = new Dictionary<string, int>();
            foreach (var cell in headRow.Cells)
            {
                var colName = (cell.StringCellValue ?? string.Empty).Trim();
                if (string.IsNullOrEmpty(colName) || dictColumns.ContainsKey(colName))
                {
                    continue;
                }

                dictColumns.Add(colName, cell.ColumnIndex);
            }

            OrderModel lastOrder = null;
            for (var rowIndex = 1; rowIndex < sheet.PhysicalNumberOfRows; rowIndex++)
            {
                if(rowIndex >= 49)
                {

                }
                var row = sheet.GetRow(rowIndex);
                if (row == null)
                {
                    continue;
                }

                var o = new OrderModel();
                o.JD订单号 = GetStringValue(lastOrder?.JD订单号, row, dictColumns, "京东订单号");
                o.淘宝订单号 = GetStringValue(lastOrder?.淘宝订单号, row, dictColumns, "淘宝订单编号");
                o.货号 = GetStringValue(lastOrder?.货号, row, dictColumns, "货号");
                o.采购备注 = GetStringValue(lastOrder?.采购备注, row, dictColumns, "备注");
                o.进货数量 = GetIntValue(lastOrder?.进货数量, row, dictColumns, "数量");
                o.京东价 = GetDecimalValue(lastOrder?.京东价, row, dictColumns, "京东价");
                o.成本价 = GetDecimalValue(lastOrder?.京东价, row, dictColumns, "成本价");
                o.来快递单号 = GetStringValue(lastOrder?.来快递单号, row, dictColumns, "快递单号");
                o.客人姓名 = GetStringValue(lastOrder?.客人姓名, row, dictColumns, "收件人");
                o.客人电话 = GetStringValue(lastOrder?.客人电话, row, dictColumns, "电话");
                o.客人地址 = GetStringValue(lastOrder?.客人地址, row, dictColumns, "地址");
                o.店铺 = GetStringValue(lastOrder?.店铺, row, dictColumns, "店铺名称");
                o.进货日期 = GetDateTimeValue(lastOrder?.进货日期, row, dictColumns, "进货日期");
                o.RowIndex = rowIndex;

                if (string.IsNullOrEmpty(o.货号))
                {
                    lastOrder = null;
                    continue;
                }

                orders.Add(o);
                lastOrder = o;
            }

            wk.Close();

            return orders;
        }

        #endregion 导入采购订单

        #region Excel 公用

        private static string GetStringValue(string lastValue, IRow row, Dictionary<string, int> dictColumns, params string[] columnNames)
        {
            foreach (var colName in columnNames)
            {
                if (!dictColumns.ContainsKey(colName))
                {
                    continue;
                }

                var cell = row.GetCell(dictColumns[colName]);
                if (cell == null)
                {
                    return lastValue ?? string.Empty;
                }

                var strVal = default(string);
                switch (cell.CellType)
                {
                    case CellType.Formula:
                    case CellType.String:
                        strVal = cell.StringCellValue;
                        break;
                    case CellType.Numeric:
                        strVal = cell.NumericCellValue.ToString();
                        break;
                }

                return strVal;
            }

            return string.Empty;
        }

        private static int? GetIntValue(int? lastValue, IRow row, Dictionary<string, int> dictColumns, params string[] columnNames)
        {
            foreach (var colName in columnNames)
            {
                if (!dictColumns.ContainsKey(colName))
                {
                    continue;
                }

                var cell = row.GetCell(dictColumns[colName]);
                if (cell == null)
                {
                    return lastValue;
                }

                var cellVal = cell.NumericCellValue;
                return Convert.ToInt32(cellVal);
            }

            return null;
        }

        private static Decimal? GetDecimalValue(Decimal? lastValue, IRow row, Dictionary<string, int> dictColumns, params string[] columnNames)
        {
            foreach (var colName in columnNames)
            {
                if (!dictColumns.ContainsKey(colName))
                {
                    continue;
                }

                var cell = row.GetCell(dictColumns[colName]);
                if (cell == null)
                {
                    return lastValue;
                }

                switch (cell.CellType)
                {
                    case CellType.Formula:
                    case CellType.String:
                        return Convert.ToDecimal(cell.StringCellValue);
                    case CellType.Numeric:
                        return Convert.ToDecimal(cell.NumericCellValue);
                }
            }

            return null;
        }

        private static DateTime? GetDateTimeValue(DateTime? lastValue, IRow row, Dictionary<string, int> dictColumns, params string[] columnNames)
        {
            foreach (var colName in columnNames)
            {
                if (!dictColumns.ContainsKey(colName))
                {
                    continue;
                }

                var cell = row.GetCell(dictColumns[colName]);
                if (cell == null)
                {
                    return lastValue;
                }

                switch (cell.CellType)
                {
                    case CellType.String:
                        return Convert.ToDateTime(cell.StringCellValue);
                    default:
                        return cell.DateCellValue;
                }
            }

            return null;
        }

        private static bool SetStringValue(IRow row, string val, Dictionary<string, int> dictColumns, params string[] columnNames)
        {
            foreach (var colName in columnNames)
            {
                if (!dictColumns.ContainsKey(colName))
                {
                    continue;
                }

                var cell = row.GetCell(dictColumns[colName]);
                if (cell == null)
                {
                    cell = row.CreateCell(dictColumns[colName]);
                }

                cell.SetCellValue(val);
                return true;
            }

            return false;
        }

        public bool WriteExcel导入结果Update(Stream excelStream, string targetColumnName, bool isXlsx, IList<OrderModel> orders, string file)
        {
            excelStream.Position = 0;
            IWorkbook wk = null;
            if (isXlsx)
            {
                wk = new XSSFWorkbook(excelStream);
            }
            else
            {
                wk = new HSSFWorkbook(excelStream);
            }

            //获取第一个sheet
            ISheet sheet = wk.GetSheetAt(0);
            //获取第一行
            IRow headRow = sheet.GetRow(0);

            var dictColumns = new Dictionary<string, int>();
            foreach (var cell in headRow.Cells)
            {
                var colName = (cell.StringCellValue ?? string.Empty).Trim();
                if (string.IsNullOrEmpty(colName) || dictColumns.ContainsKey(colName))
                {
                    continue;
                }

                dictColumns.Add(colName, cell.ColumnIndex);
            }

            for (var rowIndex = 1; rowIndex < sheet.PhysicalNumberOfRows; rowIndex++)
            {
                var row = sheet.GetRow(rowIndex);
                if (row == null)
                {
                    continue;
                }

                var order = orders.FirstOrDefault(m => m.RowIndex.GetValueOrDefault() == rowIndex);
                if (order == null)
                {
                    continue;
                }

                if (!order.导入结果.HasValue)
                {
                    continue;
                }

                var 处理结果 = string.Empty;
                switch (order.导入结果.Value)
                {
                    case 0:
                        处理结果 = "未找到";
                        break;
                    case 1:
                        处理结果 = "无更改";
                        break;
                    case 2:
                        处理结果 = "已更新";
                        break;
                }

                var success = SetStringValue(row, 处理结果, dictColumns, targetColumnName);
                if (!success)
                {
                    return false;
                }
            }

            using (var stream = new FileStream(file, FileMode.Create, FileAccess.Write))
            {
                wk.Write(stream);
            }

            wk.Close();

            return true;
        }

        public bool WriteExcel导入结果Create(Stream excelStream, string targetColumnName, bool isXlsx, IList<OrderModel> orders, string file)
        {
            excelStream.Position = 0;
            IWorkbook wk = null;
            if (isXlsx)
            {
                wk = new XSSFWorkbook(excelStream);
            }
            else
            {
                wk = new HSSFWorkbook(excelStream);
            }

            //获取第一个sheet
            ISheet sheet = wk.GetSheetAt(0);
            //获取第一行
            IRow headRow = sheet.GetRow(0);

            var dictColumns = new Dictionary<string, int>();
            foreach (var cell in headRow.Cells)
            {
                var colName = (cell.StringCellValue ?? string.Empty).Trim();
                if (string.IsNullOrEmpty(colName) || dictColumns.ContainsKey(colName))
                {
                    continue;
                }

                dictColumns.Add(colName, cell.ColumnIndex);
            }

            for (var rowIndex = 1; rowIndex < sheet.PhysicalNumberOfRows; rowIndex++)
            {
                var row = sheet.GetRow(rowIndex);
                if (row == null)
                {
                    continue;
                }

                var order = orders.FirstOrDefault(m => m.RowIndex.GetValueOrDefault() == rowIndex);
                if (order == null)
                {
                    continue;
                }

                if (!order.导入结果.HasValue)
                {
                    continue;
                }

                var 处理结果 = string.Empty;
                switch (order.导入结果.Value)
                {
                    case 0:
                        处理结果 = "未导入";
                        break;
                    case 1:
                        处理结果 = "成功";
                        break;
                }

                var success = SetStringValue(row, 处理结果, dictColumns, targetColumnName);
                if (!success)
                {
                    return false;
                }
            }

            using (var stream = new FileStream(file, FileMode.Create, FileAccess.Write))
            {
                wk.Write(stream);
            }

            wk.Close();

            return true;
        }

        #endregion
    }
}
