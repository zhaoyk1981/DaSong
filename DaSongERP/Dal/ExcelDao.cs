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
        public IList<OrderModel> Read(Stream excelStream, bool isXlsx)
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
            IRow headrow = sheet.GetRow(0);

            int? idxJD订单号 = null;
            int? idx电话备注 = null;
            for (var i = 0; i < headrow.PhysicalNumberOfCells; i++)
            {
                var value = (headrow.Cells[i].StringCellValue ?? string.Empty).Trim();
                if (string.Compare(value, "销售平台单号", true) == 0)
                {
                    idxJD订单号 = i;
                }
                else if (string.Compare(value, "电话备注", true) == 0)
                {
                    idx电话备注 = i;
                }

                if (idxJD订单号.HasValue && idx电话备注.HasValue)
                {
                    break;
                }
            }

            if (!idxJD订单号.HasValue || !idx电话备注.HasValue)
            {
                return orders;
            }

            OrderModel lastOrder = null;
            for (var rowIndex = 1; rowIndex < sheet.PhysicalNumberOfRows; rowIndex++)
            {
                var row = sheet.GetRow(rowIndex);
                if (row == null)
                {
                    continue;
                }

                var cell电话备注 = row.GetCell(idx电话备注.Value);
                if (cell电话备注 == null)
                {
                    continue;
                }

                var 电话备注 = (cell电话备注.StringCellValue ?? string.Empty).Trim();
                var JD订单号 = string.Empty;
                var cellJD订单号 = row.GetCell(idxJD订单号.Value);
                if (cellJD订单号 == null)
                {
                    if (lastOrder == null)
                    {
                        continue;
                    }

                    JD订单号 = lastOrder.JD订单号;
                }
                else
                {
                    JD订单号 = (cellJD订单号.StringCellValue ?? string.Empty).Trim();
                }

                if (string.IsNullOrEmpty(JD订单号))
                {
                    continue;
                }

                if (string.IsNullOrEmpty(电话备注))
                {
                    if (JD订单号 == lastOrder?.JD订单号)
                    {
                        电话备注 = lastOrder.电话备注;
                    }
                    else
                    {
                        continue;
                    }
                }

                var o = new OrderModel();
                orders.Add(o);
                o.JD订单号 = JD订单号;
                o.电话备注 = 电话备注;
                o.RowIndex = rowIndex;
                lastOrder = o;
            }

            wk.Close();

            return orders;
        }

        public bool Write(Stream excelStream, bool isXlsx, IList<OrderModel> orders, string file)
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
            IRow headrow = sheet.GetRow(0);

            int? idx处理结果 = null;
            for (var i = 0; i < headrow.PhysicalNumberOfCells; i++)
            {
                var value = (headrow.Cells[i].StringCellValue ?? string.Empty).Trim();
                if (string.Compare(value, "处理结果", true) == 0)
                {
                    idx处理结果 = i;
                }

                if (idx处理结果.HasValue)
                {
                    break;
                }
            }

            if (!idx处理结果.HasValue)
            {
                return false;
            }

            for (var rowIndex = 1; rowIndex < sheet.PhysicalNumberOfRows; rowIndex++)
            {
                var row = sheet.GetRow(rowIndex);
                if (row == null)
                {
                    continue;
                }

                var cell处理结果 = row.GetCell(idx处理结果.Value);
                if (cell处理结果 == null)
                {
                    cell处理结果 = row.CreateCell(idx处理结果.Value);
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

                cell处理结果.SetCellValue(处理结果);
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
