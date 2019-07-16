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
            var o = this.OrderDao.GetOrderBy订单号(order);
            Set店铺(o);
            return o;
        }

        //public IList<OrderModel> GetOrdersBy(string jd订单号, string 来快递单号)
        //{
        //    var orders = this.OrderDao.GetOrdersBy(jd订单号, 来快递单号);
        //    Set店铺(orders);
        //    return orders;
        //}

        public OrderModel GetOrderBy(Guid id)
        {
            var order = this.OrderDao.GetOrderBy(id);
            Set店铺(order);
            return order;
        }

        public EditOrderViewModel GetEditOrderViewModel(Guid id)
        {
            var vm = new EditOrderViewModel();
            vm.Order = this.GetOrderBy(id);
            Set店铺(vm.Order);
            return vm;
        }

        public EditOrderViewModel Get跟进ViewModel(Guid id)
        {
            var vm = new EditOrderViewModel();
            vm.来快递DataSource = this.OrderDao.GetAll快递();
            vm.Order = this.GetOrderBy(id);
            Set店铺(vm.Order);
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
            var orders = OrderDao.Get未导入Orders();
            Set店铺(orders);
            return orders;
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
            Set店铺(vm.Order);
            return vm;
        }

        public int Update售后(OrderModel order)
        {
            order.售后人员ID = this.UserID;
            order.订单修改备注 = this.生成订单修改备注(order, "售后");
            var rowCount = OrderDao.Update售后(order);
            return rowCount;
        }

        public EditOrderViewModel Get售后OrderViewModel(Guid id)
        {
            var vm = new EditOrderViewModel();
            vm.售后操作DataSource = MetaDao.Get售后操作();
            vm.售后原因DataSource = MetaDao.Get售后原因();
            vm.Order = this.GetOrderBy(id);
            Set店铺(vm.Order);
            return vm;
        }

        public EditOrderViewModel Get客服OrderViewModel(Guid id)
        {
            var vm = new EditOrderViewModel();
            vm.Order = this.GetOrderBy(id);
            Set店铺(vm.Order);
            return vm;
        }

        public int Update客服(OrderModel order)
        {
            order.客服ID = this.UserID;
            order.订单修改备注 = this.生成订单修改备注(order, "客服");
            var rowCount = OrderDao.Update客服(order);
            return rowCount;
        }

        //public OrderListViewModel GetOrderListViewModel(string jd订单号)
        //{
        //    var vm = new OrderListViewModel();
        //    vm.Orders = this.GetOrdersBy(jd订单号, null);
        //    vm.JD订单号 = jd订单号;
        //    return vm;
        //}

        public IList<OrderModel> GetOrdersBy来快递单号(string 来快递单号)
        {
            var list = OrderDao.GetOrdersBy(null, 来快递单号);
            Set店铺(list);
            return list;
        }

        //public IList<OrderModel> GetOrdersBy(OrderModel condition)
        //{
        //    var list = OrderDao.GetOrdersBy(condition);
        //    return list;
        //}

        //public OrderListViewModel GetOrderListViewModel(OrderModel condition)
        //{
        //    var vm = new OrderListViewModel();
        //    vm.Orders = condition.Search.GetValueOrDefault() ? OrderDao.GetOrdersBy(condition) : new List<OrderModel>();
        //    vm.Condition = condition;
        //    return vm;
        //}

        //public OrderListViewModel GetChaiBaoOrderListViewModel(string 来快递单号)
        //{
        //    var vm = new OrderListViewModel();
        //    vm.Orders = this.GetOrdersBy来快递单号(来快递单号);
        //    vm.来快递单号 = 来快递单号;
        //    return vm;
        //}

        //public OrderListViewModel GetImportOrderListViewModel()
        //{
        //    var vm = new OrderListViewModel();
        //    vm.Orders = this.Get未导入Orders();
        //    return vm;
        //}

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
            Set店铺(list.DataSource);
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
            Set店铺(list.DataSource);
            return list;
        }

        public EditOrderViewModel Get电话客服ViewModel(Guid id)
        {
            var vm = new EditOrderViewModel();
            vm.Order = this.GetOrderBy(id);
            Set店铺(vm.Order);
            return vm;
        }

        public int Update电话客服(OrderModel order)
        {
            order.电话客服ID = this.UserID;
            order.订单修改备注 = this.生成订单修改备注(order, "电话客服");
            var rowCount = this.OrderDao.Update电话客服(order);
            return rowCount;
        }

        private string 生成订单修改备注(OrderModel newOrder, string role)
        {
            var oldOrder = this.GetOrderBy(newOrder.ID.Value);
            if (oldOrder.客人地址 == newOrder.客人地址)
            {
                return string.Empty;
            }

            var user = this.UserDao.GetUserBy(this.UserID.Value);

            return $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} - {role} {user.Name} 修改了客人地址(JD订单号:{oldOrder.JD订单号})，\r\n原值为\"{oldOrder.客人地址}\"，\r\n新值为\"{newOrder.客人地址}\"。\r\n";
        }

        public 采购ListViewModel Get采购ListViewModel()
        {
            var vm = new 采购ListViewModel();
            vm.Orders = new PagedList<OrderModel>();
            vm.Orders.PageSize = 300;
            return vm;
        }

        public PagedList<OrderModel> Get采购List(OrderCondition condition)
        {
            condition.Trim();
            if (condition.My.GetValueOrDefault())
            {
                condition.采购人ID = this.UserID;
            }

            var list = this.OrderDao.Get采购List(condition);
            Set店铺(list.DataSource);
            return list;
        }

        public 拆包审单ListViewModel Get拆包审单ListViewModel()
        {
            var vm = new 拆包审单ListViewModel();
            vm.Orders = new PagedList<OrderModel>();
            vm.Orders.PageSize = 300;
            return vm;
        }

        public PagedList<OrderModel> Get拆包审单List(OrderCondition condition)
        {
            condition.Trim();
            if (condition.My.GetValueOrDefault())
            {
                condition.拆包人ID = this.UserID;
            }

            var list = this.OrderDao.Get拆包审单List(condition);
            Set店铺(list.DataSource);
            return list;
        }

        public 售后ListViewModel Get售后ListViewModel()
        {
            var vm = new 售后ListViewModel();
            vm.Orders = new PagedList<OrderModel>();
            vm.Orders.PageSize = 300;
            return vm;
        }

        public PagedList<OrderModel> Get售后List(OrderCondition condition)
        {
            condition.Trim();
            if (condition.My.GetValueOrDefault())
            {
                condition.售后人员ID = this.UserID;
            }

            var list = this.OrderDao.Get售后List(condition);
            Set店铺(list.DataSource);
            return list;
        }

        public 客服ListViewModel Get客服ListViewModel()
        {
            var vm = new 客服ListViewModel();
            vm.Orders = new PagedList<OrderModel>();
            vm.Orders.PageSize = 300;
            return vm;
        }

        public PagedList<OrderModel> Get客服List(OrderCondition condition)
        {
            condition.Trim();
            if (condition.My.GetValueOrDefault())
            {
                condition.客服ID = this.UserID;
            }

            var list = this.OrderDao.Get客服List(condition);
            Set店铺(list.DataSource);
            return list;
        }

        public OrderCountModel Get待处理订单数量()
        {
            return OrderDao.Get待处理订单数量();
        }

        private IList<店铺Model> 店铺List { get; set; }

        private void Set店铺(IList<OrderModel> orders)
        {
            if (orders == null)
            {
                return;
            }

            foreach (var o in orders)
            {
                Set店铺(o);
            }
        }

        private void Set店铺(OrderModel order)
        {
            if (order == null)
            {
                return;
            }

            order.店铺名称 = $"店铺账号：{order.店铺}";
            if (店铺List == null)
            {
                店铺List = this.MetaDao.GetAll店铺();
            }

            var idx = (order.店铺 ?? string.Empty).IndexOf("_");
            var prefix = idx <= 0 ? (order.店铺 ?? string.Empty).Trim() : order.店铺.Substring(0, idx).Trim();
            if (string.IsNullOrWhiteSpace(prefix))
            {
                return;
            }

            var shop = 店铺List.FirstOrDefault(m => string.Compare(m.Prefix, prefix, true) == 0);
            if (shop == null)
            {
                return;
            }

            order.店铺名称 = shop.Name;
        }
    }
}
