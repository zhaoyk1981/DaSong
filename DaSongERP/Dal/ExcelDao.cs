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

            var dictColumns = GetAllColumns(headRow);
            var dictCellStatus = GetAllCellStatus(sheet);

            OrderModel lastOrder = null;
            for (var rowIndex = 1; rowIndex < sheet.PhysicalNumberOfRows; rowIndex++)
            {
                var row = sheet.GetRow(rowIndex);
                if (row == null)
                {
                    continue;
                }

                var o = new OrderModel();
                o.电话备注 = GetStringValue(lastOrder?.电话备注, rowIndex, row, dictColumns, dictCellStatus, "电话备注");
                o.JD订单号 = GetStringValue(lastOrder?.JD订单号, rowIndex, row, dictColumns, dictCellStatus, "销售平台单号");
                o.客人姓名 = GetStringValue(lastOrder?.客人姓名, rowIndex, row, dictColumns, dictCellStatus, "收件人");
                o.客人电话 = GetStringValue(lastOrder?.客人电话, rowIndex, row, dictColumns, dictCellStatus, "电话");
                o.客人地址 = GetStringValue(lastOrder?.客人地址, rowIndex, row, dictColumns, dictCellStatus, "地址");
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

            var dictColumns = GetAllColumns(headRow);
            var dictCellStatus = GetAllCellStatus(sheet);

            for (var rowIndex = 1; rowIndex < sheet.PhysicalNumberOfRows; rowIndex++)
            {
                var row = sheet.GetRow(rowIndex);
                if (row == null)
                {
                    continue;
                }

                var o = new OrderModel();
                o.JD订单号 = GetStringValue(null, rowIndex, row, dictColumns, dictCellStatus, "订单号");
                o.转发单号 = GetStringValue(null, rowIndex, row, dictColumns, dictCellStatus, "运单号");
                o.RowIndex = rowIndex;

                if (string.IsNullOrEmpty(o.JD订单号))
                {
                    continue;
                }

                if (string.IsNullOrEmpty(o.转发单号))
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

            var dictColumns = GetAllColumns(headRow);
            var dictCellStatus = GetAllCellStatus(sheet);

            OrderModel lastOrder = null;
            for (var rowIndex = 1; rowIndex < sheet.PhysicalNumberOfRows; rowIndex++)
            {
                if (rowIndex >= 49)
                {

                }
                var row = sheet.GetRow(rowIndex);
                if (row == null)
                {
                    continue;
                }

                var o = new OrderModel();
                o.JD订单号 = GetStringValue(lastOrder?.JD订单号, rowIndex, row, dictColumns, dictCellStatus, "京东订单号");
                o.淘宝订单号 = GetStringValue(lastOrder?.淘宝订单号, rowIndex, row, dictColumns, dictCellStatus, "淘宝订单编号");
                o.货号 = GetStringValue(lastOrder?.货号, rowIndex, row, dictColumns, dictCellStatus, "货号");
                o.采购备注 = GetStringValue(lastOrder?.采购备注, rowIndex, row, dictColumns, dictCellStatus, "备注");
                o.进货数量 = GetIntValue(lastOrder?.进货数量, rowIndex, row, dictColumns, dictCellStatus, "进货数量");
                o.京东价 = GetDecimalValue(lastOrder?.京东价, rowIndex, row, dictColumns, dictCellStatus, "京东价");
                o.成本价 = GetDecimalValue(lastOrder?.京东价, rowIndex, row, dictColumns, dictCellStatus, "成本价");
                o.来快递 = GetStringValue(lastOrder?.来快递, rowIndex, row, dictColumns, dictCellStatus, "快递名称");
                o.来快递单号 = GetStringValue(lastOrder?.来快递单号, rowIndex, row, dictColumns, dictCellStatus, "快递单号");
                o.转发单号 = GetStringValue(lastOrder?.转发单号, rowIndex, row, dictColumns, dictCellStatus, "转发单号");
                o.淘宝账号 = GetStringValue(lastOrder?.淘宝账号, rowIndex, row, dictColumns, dictCellStatus, "淘宝账号");
                o.客人姓名 = GetStringValue(lastOrder?.客人姓名, rowIndex, row, dictColumns, dictCellStatus, "收件人");
                o.客人电话 = GetStringValue(lastOrder?.客人电话, rowIndex, row, dictColumns, dictCellStatus, "电话");
                o.客人地址 = GetStringValue(lastOrder?.客人地址, rowIndex, row, dictColumns, dictCellStatus, "地址");
                o.店铺 = GetStringValue(lastOrder?.店铺, rowIndex, row, dictColumns, dictCellStatus, "店铺名称");
                o.进货日期 = GetDateTimeValue(lastOrder?.进货日期, rowIndex, row, dictColumns, dictCellStatus, "进货日期");
                o.现货 = GetStringValue("", rowIndex, row, dictColumns, dictCellStatus, "现货") == "是";
                o.中转仓 = GetStringValue(lastOrder?.中转仓, rowIndex, row, dictColumns, dictCellStatus, "中转仓");
                if (string.IsNullOrEmpty(o.中转仓))
                {
                    o.中转仓 = "天津";
                }

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

        private IDictionary<string, int> GetAllColumns(IRow headRow)
        {
            var dictColumns = new Dictionary<string, int>();
            foreach (var cell in headRow.Cells)
            {
                var colName = (cell.StringCellValue ?? string.Empty).Trim()
                    .Replace("\r", "")
                    .Replace("\n", "")
                    .Replace(" ", "");

                if (string.IsNullOrEmpty(colName) || dictColumns.ContainsKey(colName))
                {
                    continue;
                }

                dictColumns.Add(colName, cell.ColumnIndex);
            }

            return dictColumns;
        }

        private IDictionary<string, CellStatus> GetAllCellStatus(ISheet sheet)
        {
            var dict = new Dictionary<string, CellStatus>();
            for (var i = 1; i < sheet.PhysicalNumberOfRows; i++)
            {
                var row = sheet.GetRow(i);
                for (var j = 0; j < row.PhysicalNumberOfCells; j++)
                {
                    var key = $"{i},{j}";
                    var cellStatus = 0;
                    var cell = row.GetCell(j);
                    if (cell == null)
                    {
                        if (i == 1)
                        {
                            dict.Add(key, CellStatus.None);
                            continue;
                        }
                        else
                        {
                            var upCellStatus = dict[$"{i - 1},{j}"];
                            if ((upCellStatus & CellStatus.Merged) == CellStatus.Merged)
                            {
                                dict.Add(key, CellStatus.Merged);
                            }
                            else
                            {
                                dict.Add(key, CellStatus.None);
                            }
                        }
                    }
                    else
                    {
                        cellStatus = (int)CellStatus.Exists;
                        if (cell.IsMergedCell)
                        {
                            cellStatus += (int)CellStatus.Merged;
                        }

                        dict.Add(key, (CellStatus)cellStatus);
                    }
                }
            }

            return dict;
        }

        private static string GetStringValue(string lastValue, int rowIndex, IRow row, IDictionary<string, int> dictColumns, IDictionary<string, CellStatus> dictCellStatus, params string[] columnNames)
        {
            foreach (var colName in columnNames)
            {
                if (!dictColumns.ContainsKey(colName))
                {
                    continue;
                }

                var cellIndex = dictColumns[colName];
                var cell = row.GetCell(cellIndex);
                var upCellKey = $"{rowIndex - 1},{cellIndex}";
                var upCellStatus = dictCellStatus.ContainsKey(upCellKey) ? dictCellStatus[upCellKey] : CellStatus.None;
                if (cell == null)
                {
                    if ((upCellStatus & CellStatus.Merged) == CellStatus.Merged)
                    {
                        return lastValue ?? string.Empty;
                    }

                    return string.Empty;
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

                if (!string.IsNullOrEmpty(strVal))
                {
                    strVal = strVal.Replace("\t", "");
                }

                return strVal;
            }

            return string.Empty;
        }

        private static int? GetIntValue(int? lastValue, int rowIndex, IRow row, IDictionary<string, int> dictColumns, IDictionary<string, CellStatus> dictCellStatus, params string[] columnNames)
        {
            foreach (var colName in columnNames)
            {
                if (!dictColumns.ContainsKey(colName))
                {
                    continue;
                }

                var cellIndex = dictColumns[colName];
                var cell = row.GetCell(cellIndex);
                var upCellKey = $"{rowIndex - 1},{cellIndex}";
                var upCellStatus = dictCellStatus.ContainsKey(upCellKey) ? dictCellStatus[upCellKey] : CellStatus.None;
                if (cell == null)
                {
                    if ((upCellStatus & CellStatus.Merged) == CellStatus.Merged)
                    {
                        return lastValue;
                    }

                    return null;
                }

                var cellVal = cell.NumericCellValue;
                return Convert.ToInt32(cellVal);
            }

            return null;
        }

        private static Decimal? GetDecimalValue(Decimal? lastValue, int rowIndex, IRow row, IDictionary<string, int> dictColumns, IDictionary<string, CellStatus> dictCellStatus, params string[] columnNames)
        {
            foreach (var colName in columnNames)
            {
                if (!dictColumns.ContainsKey(colName))
                {
                    continue;
                }

                var cellIndex = dictColumns[colName];
                var cell = row.GetCell(cellIndex);
                var upCellKey = $"{rowIndex - 1},{cellIndex}";
                var upCellStatus = dictCellStatus.ContainsKey(upCellKey) ? dictCellStatus[upCellKey] : CellStatus.None;
                if (cell == null)
                {
                    if ((upCellStatus & CellStatus.Merged) == CellStatus.Merged)
                    {
                        return lastValue;
                    }

                    return null;
                }

                switch (cell.CellType)
                {
                    case CellType.String:
                        return Convert.ToDecimal(cell.StringCellValue);
                    case CellType.Formula:
                    case CellType.Numeric:
                        return Convert.ToDecimal(cell.NumericCellValue);
                }
            }

            return null;
        }



        private static DateTime? GetDateTimeValue(DateTime? lastValue, int rowIndex, IRow row, IDictionary<string, int> dictColumns, IDictionary<string, CellStatus> dictCellStatus, params string[] columnNames)
        {
            foreach (var colName in columnNames)
            {
                if (!dictColumns.ContainsKey(colName))
                {
                    continue;
                }

                var cellIndex = dictColumns[colName];
                var cell = row.GetCell(cellIndex);
                var upCellKey = $"{rowIndex - 1},{cellIndex}";
                var upCellStatus = dictCellStatus.ContainsKey(upCellKey) ? dictCellStatus[upCellKey] : CellStatus.None;
                if (cell == null)
                {
                    if ((upCellStatus & CellStatus.Merged) == CellStatus.Merged)
                    {
                        return lastValue;
                    }

                    return null;
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

        private static bool SetStringValue(IRow row, string val, IDictionary<string, int> dictColumns, bool appendWhenNotFound, params string[] columnNames)
        {
            int? colIndex = appendWhenNotFound ? dictColumns.Values.Max() + 1 : default(int?);
            foreach (var colName in columnNames)
            {
                if (!dictColumns.ContainsKey(colName))
                {

                    continue;
                }

                colIndex = dictColumns[colName];
                break;
            }

            if (!colIndex.HasValue)
            {
                return false;
            }

            var cell = row.GetCell(colIndex.Value);
            if (cell == null)
            {
                cell = row.CreateCell(colIndex.Value);
            }

            cell.SetCellValue(val);
            return true;
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

            var dictColumns = GetAllColumns(headRow);

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

                var success = SetStringValue(row, 处理结果, dictColumns, true, targetColumnName);
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

            var dictColumns = GetAllColumns(headRow);

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

                var success = SetStringValue(row, 处理结果, dictColumns, true, targetColumnName);
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
