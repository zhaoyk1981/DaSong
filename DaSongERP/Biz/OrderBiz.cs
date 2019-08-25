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
            vm.中转仓DataSource = this.MetaDao.GetAll中转仓();
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

            var rowCount = this.OrderDao.Create(order);

            this.订单动量(order.ID.Value);

            return rowCount;
        }

        private void 订单动量(Guid orderId, bool update = false)
        {
            var savedOrder = this.GetOrderBy(orderId);
            var stockBiz = new 库存商品Biz();

            if (savedOrder.订单终结.GetValueOrDefault())
            {
                库存商品Dao.Delete库存动量(orderId);
            }
            else if (savedOrder.现货.GetValueOrDefault())
            {
                stockBiz.现货动量(savedOrder, update);
            }
            else if (savedOrder.自采.GetValueOrDefault())
            {
                stockBiz.自采在途动量(savedOrder);
            }
            else
            {
                库存商品Dao.Delete库存动量(orderId);
            }
        }

        public OrderModel GetOrderBy订单号(OrderModel order)
        {
            var o = this.OrderDao.GetOrderBy订单号(order);
            Set店铺(o);
            return o;
        }

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
            vm.中转仓DataSource = this.MetaDao.GetAll中转仓();
            vm.规格DataSource = new 库存商品Biz().Get规格Options(new 库存商品Condition()
            {
                货号 = vm.Order?.货号,
                仓库 = vm.Order?.中转仓
            });

            Set店铺(vm.Order);
            return vm;
        }

        public EditOrderViewModel Get跟进ViewModel(Guid id)
        {
            var vm = new EditOrderViewModel();
            vm.来快递DataSource = this.MetaDao.GetAll快递();
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
            this.订单动量(order.ID.Value, true);
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
            var ordersInExcel = ExcelDao.ReadExcel电话客服(excelStream, isXlsx);
            foreach (var order in ordersInExcel)
            {
                order.导入结果 = OrderDao.Update电话备注(order);
            }

            var file = $"电话客服导入结果_{DateTime.Now.ToString("yyyyMMddHHmmss")}.xls{(isXlsx ? "x" : "")}";
            var path = $"{HttpContext.Current.Server.MapPath("~/Excel")}\\{file}";
            ExcelDao.WriteExcel导入结果Update(memStream, "处理结果", isXlsx, ordersInExcel, path);
            return file;
        }

        public string 导入采购订单(Stream excelStream, bool isXlsx)
        {
            var memStream = new MemoryStream();
            excelStream.CopyTo(memStream);
            var ordersInExcel = ExcelDao.ReadExcel采购订单(excelStream, isXlsx);
            foreach (var order in ordersInExcel)
            {
                order.采购人ID = this.UserID;
                order.导入结果 = OrderDao.Create4Excel(order);
            }

            var file = $"采购订单导入结果_{DateTime.Now.ToString("yyyyMMddHHmmss")}.xls{(isXlsx ? "x" : "")}";
            var path = $"{HttpContext.Current.Server.MapPath("~/Excel")}\\{file}";
            ExcelDao.WriteExcel导入结果Create(memStream, "处理结果", isXlsx, ordersInExcel, path);
            return file;
        }

        public string 批量导入运单号(Stream excelStream, bool isXlsx)
        {
            var memStream = new MemoryStream();
            excelStream.CopyTo(memStream);
            var ordersInExcel = ExcelDao.ReadExcel拆包审单(excelStream, isXlsx);
            foreach (var order in ordersInExcel)
            {
                order.转发单号 = order.转发单号.Replace("\"", "").Trim();
                order.拆包人ID = this.UserID;
                order.导入结果 = OrderDao.Update拆包4Excel(order);
            }

            var file = $"导入运单号结果_{DateTime.Now.ToString("yyyyMMddHHmmss")}.xls{(isXlsx ? "x" : "")}";
            var path = $"{HttpContext.Current.Server.MapPath("~/Excel")}\\{file}";
            ExcelDao.WriteExcel导入结果Update(memStream, "处理结果", isXlsx, ordersInExcel, path);
            return file;
        }

        public IList<OrderModel> Get未导入Orders()
        {
            var orders = OrderDao.Get未导入Orders();
            Set店铺(orders);
            return orders;
        }

        private static readonly Guid 正常发走ID = new Guid("8D1DB75A-B976-47D1-9BA2-3CBA8042C369");

        public int Update拆包(OrderModel order)
        {
            order.拆包人ID = this.UserID;
            order.订单修改备注 = string.Empty;
            order.转发单号 = order.转发单号.Replace("\"", "").Trim();
            order.在途待发 = order.审单操作ID.GetValueOrDefault() == 正常发走ID ? false : default(bool?);

            if (order.审单操作ID.Value == Guid.Empty)
            {
                order.审单操作ID = null;
                order.转发单号 = string.Empty;
                order.订单修改备注 = this.生成订单修改备注_拆包审单(order, "拆包人");
            }

            var rowCount = OrderDao.Update拆包(order);
            if (order.入库数量.GetValueOrDefault() > 0)
            {
                var savedOrder = this.GetOrderBy(order.ID.Value);
                var stockBiz = new 库存商品Biz();

                if (savedOrder.自采.GetValueOrDefault() && savedOrder.审单操作.入库.GetValueOrDefault())
                {
                    stockBiz.自采入库动量(savedOrder);
                }
            }

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
            order.订单修改备注 = this.生成订单修改备注_客人地址(order, "售后");
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
            order.订单修改备注 = this.生成订单修改备注_客人地址(order, "客服");
            var rowCount = OrderDao.Update客服(order);
            return rowCount;
        }

        public IList<OrderModel> GetOrdersBy来快递单号(string 来快递单号)
        {
            var list = OrderDao.GetOrdersBy(null, 来快递单号);
            Set店铺(list);
            return list;
        }

        public 跟进ListViewModel Get跟进ListViewModel()
        {
            var vm = new 跟进ListViewModel();
            vm.Orders = new PagedList<OrderModel>();
            vm.Orders.PageSize = 100;
            vm.中转仓DataSource = this.MetaDao.GetAll中转仓();
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
            vm.Orders.PageSize = 100;
            vm.中转仓DataSource = MetaDao.GetAll中转仓();
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
            order.订单修改备注 = this.生成订单修改备注_客人地址(order, "电话客服");
            var rowCount = this.OrderDao.Update电话客服(order);
            return rowCount;
        }

        private string 生成订单修改备注_客人地址(OrderModel newOrder, string role)
        {
            var oldOrder = this.GetOrderBy(newOrder.ID.Value);
            var b = new StringBuilder();

            if (oldOrder.客人姓名 != newOrder.客人姓名)
            {
                b.Append($"修改了客人姓名，\r\n原值为\"{oldOrder.客人姓名}\"，\r\n新值为\"{newOrder.客人姓名}\"。\r\n");
            }

            if (oldOrder.客人电话 != newOrder.客人电话)
            {
                b.Append($"修改了客人电话，\r\n原值为\"{oldOrder.客人电话}\"，\r\n新值为\"{newOrder.客人电话}\"。\r\n");
            }

            if (oldOrder.客人地址 != newOrder.客人地址)
            {
                b.Append($"修改了客人地址，\r\n原值为\"{oldOrder.客人地址}\"，\r\n新值为\"{newOrder.客人地址}\"。\r\n");
            }

            if (b.Length == 0)
            {
                return string.Empty;
            }

            var user = this.UserDao.GetUserBy(this.UserID.Value);

            return $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} - {role}: {user.Name}, JD订单号:{oldOrder.JD订单号}\r\n{b.ToString()}";
        }

        private string 生成订单修改备注_拆包审单(OrderModel newOrder, string role)
        {
            var oldOrder = this.GetOrderBy(newOrder.ID.Value);
            var b = new StringBuilder();

            b.Append($"还原为未拆包，\r\n原审单操作为\"{oldOrder.审单操作.Name}\", 原转发单号为\"{oldOrder.转发单号}\"\r\n");

            var user = this.UserDao.GetUserBy(this.UserID.Value);

            return $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} - {role}: {user.Name}, JD订单号:{oldOrder.JD订单号}\r\n{b.ToString()}";
        }

        public 采购ListViewModel Get采购ListViewModel()
        {
            var vm = new 采购ListViewModel();
            vm.Orders = new PagedList<OrderModel>();
            vm.Orders.PageSize = 100;
            vm.中转仓DataSource = this.MetaDao.GetAll中转仓();
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
            vm.Orders.PageSize = 100;
            vm.中转仓DataSource = MetaDao.GetAll中转仓();
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
            vm.Orders.PageSize = 100;
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
            vm.Orders.PageSize = 100;
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

            order.店铺名称 = $"{order.店铺}";
            if (店铺List == null)
            {
                店铺List = this.MetaDao.GetAll店铺();
            }

            var idx = (order.店铺 ?? string.Empty).LastIndexOf("_");
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
