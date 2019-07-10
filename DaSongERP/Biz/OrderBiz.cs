using DaSongERP.Conditions;
using DaSongERP.Models;
using DaSongERP.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using YK.Model;

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
            var co = this.GetOrderBy订单号(order);
            if (co != null)
            {
                return 2;
            }

            return this.OrderDao.Create(order);
        }

        public OrderModel GetOrderBy订单号(OrderModel order)
        {
            return this.OrderDao.GetOrderBy订单号(order);
        }

        public IList<OrderModel> GetOrdersBy(string jd订单号, string 来快递单号)
        {
            return this.OrderDao.GetOrdersBy(jd订单号, 来快递单号);
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

        public EditOrderViewModel Get跟进ViewModel(Guid id)
        {
            var vm = new EditOrderViewModel();
            vm.来快递DataSource = this.OrderDao.GetAll快递();
            vm.Order = this.GetOrderBy(id);
            return vm;
        }

        public int Update(OrderModel order)
        {
            order.采购人ID = this.UserID;
            var co = this.GetOrderBy订单号(order);
            if (co != null)
            {
                return 2;
            }

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

        public IList<OrderModel> Get未导入Orders()
        {
            return OrderDao.Get未导入Orders();
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

        public int Update售后(OrderModel order)
        {
            order.售后人员ID = this.UserID;
            var rowCount = OrderDao.Update售后(order);
            return rowCount;
        }

        public EditOrderViewModel Get售后OrderViewModel(Guid id)
        {
            var vm = new EditOrderViewModel();
            vm.售后操作DataSource = MetaDao.Get售后操作();
            vm.售后原因DataSource = MetaDao.Get售后原因();
            vm.Order = this.GetOrderBy(id);
            return vm;
        }

        public EditOrderViewModel Get客服OrderViewModel(Guid id)
        {
            var vm = new EditOrderViewModel();
            vm.Order = this.GetOrderBy(id);
            return vm;
        }

        public int Update客服(OrderModel order)
        {
            order.客服ID = this.UserID;
            var rowCount = OrderDao.Update客服(order);
            return rowCount;
        }

        public OrderListViewModel GetOrderListViewModel(string jd订单号)
        {
            var vm = new OrderListViewModel();
            vm.Orders = this.GetOrdersBy(jd订单号, null);
            vm.JD订单号 = jd订单号;
            return vm;
        }

        public IList<OrderModel> GetOrdersBy来快递单号(string 来快递单号)
        {
            var list = OrderDao.GetOrdersBy(null, 来快递单号);
            return list;
        }

        public IList<OrderModel> GetOrdersBy(OrderModel condition)
        {
            var list = OrderDao.GetOrdersBy(condition);
            return list;
        }

        public OrderListViewModel GetOrderListViewModel(OrderModel condition)
        {
            var vm = new OrderListViewModel();
            vm.Orders = condition.Search.GetValueOrDefault() ? OrderDao.GetOrdersBy(condition) : new List<OrderModel>();
            vm.Condition = condition;
            return vm;
        }

        public OrderListViewModel GetChaiBaoOrderListViewModel(string 来快递单号)
        {
            var vm = new OrderListViewModel();
            vm.Orders = this.GetOrdersBy来快递单号(来快递单号);
            vm.来快递单号 = 来快递单号;
            return vm;
        }

        public OrderListViewModel GetImportOrderListViewModel()
        {
            var vm = new OrderListViewModel();
            vm.Orders = this.Get未导入Orders();
            return vm;
        }

        public 跟进ListViewModel Get跟进ListViewModel()
        {
            var vm = new 跟进ListViewModel();
            vm.Orders = new PagedList<OrderModel>();
            vm.Orders.PageSize = 300;
            return vm;
        }

        public PagedList<OrderModel> Get跟进List(OrderCondition condition)
        {
            condition.Trim();
            if (condition.My.GetValueOrDefault())
            {
                condition.跟进人ID = this.UserID;
            }

            var list = this.OrderDao.Get跟进List(condition);
            return list;
        }

        public 电话客服ListViewModel Get电话客服ListViewModel()
        {
            var vm = new 电话客服ListViewModel();
            vm.Orders = new PagedList<OrderModel>();
            vm.Orders.PageSize = 300;
            return vm;
        }

        public PagedList<OrderModel> Get电话客服List(OrderCondition condition)
        {
            condition.Trim();
            if (condition.My.GetValueOrDefault())
            {
                condition.电话客服ID = this.UserID;
            }

            var list = this.OrderDao.Get电话客服List(condition);
            return list;
        }
    }
}
