using DaSongERP.Models;
using DaSongERP.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DaSongERP.Biz
{
    public class OrderBiz : Biz
    {
        public EditOrderViewModel GetCreateOrderViewModel()
        {
            var vm = new EditOrderViewModel();
            vm.店铺DataSource = this.MetaDao.Get店铺();
            vm.淘宝账号DataSource = this.MetaDao.Get淘宝账号();
            return vm;
        }

        public int Create(OrderModel order)
        {
            order.ID = Guid.NewGuid();
            order.采购人ID = this.UserID;
            order.进货日期 = DateTime.Now;

            return this.OrderDao.Create(order);
        }

        public string GetProductImagesPath()
        {
            var p = HttpContext.Current.Server.MapPath("~/ProductImages");
            return p;
        }

        public OrderModel GetOrderBy(string jd订单号, Guid? id = null)
        {
            return this.OrderDao.GetOrderBy(jd订单号, id);
        }

        public OrderModel GetOrderBy(Guid id)
        {
            return this.OrderDao.GetOrderBy(id);
        }

        public EditOrderViewModel GetEditOrderViewModel(Guid id)
        {
            var vm = new EditOrderViewModel();
            vm.店铺DataSource = this.MetaDao.Get店铺();
            vm.淘宝账号DataSource = this.MetaDao.Get淘宝账号();
            vm.Order = this.GetOrderBy(id);
            return vm;
        }

        public int Update(OrderModel order)
        {
            order.采购人ID = this.UserID;
            var rowCount = this.OrderDao.Update(order);
            return rowCount;
        }

        public int 订单跟进(OrderModel order)
        {
            order.发货时间 = DateTime.Now;
            order.跟进人ID = this.UserID;
            var rowCount = this.OrderDao.订单跟进(order);
            return rowCount;
        }

        public string 电话客服导入(Stream excelStream, bool isXlsx)
        {
            var memStream = new MemoryStream();
            excelStream.CopyTo(memStream);
            var ordersInExcel = ExcelDao.Read(excelStream, isXlsx);
            foreach (var order in ordersInExcel)
            {
                order.导入结果 = OrderDao.Update电话备注(order);
            }

            var file = $"导入结果_{DateTime.Now.ToString("yyyyMMddHHmmss")}.xls{(isXlsx ? "x" : "")}";
            var path = $"{HttpContext.Current.Server.MapPath("~/Excel")}\\{file}";
            ExcelDao.Write(memStream, isXlsx, ordersInExcel, path);
            return file;
        }

        public int Count未导入()
        {
            return OrderDao.Count未导入();
        }

        public int Update拆包(OrderModel order)
        {
            order.拆包人ID = this.UserID;
            var rowCount = OrderDao.Update拆包(order);
            return rowCount;
        }

        public EditOrderViewModel GetChaiBaoOrderViewModel(Guid id)
        {
            var vm = new EditOrderViewModel();
            vm.审单操作DataSource = this.MetaDao.Get审单操作();
            vm.Order = this.GetOrderBy(id);
            return vm;
        }
    }
}
