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
            var rowCount = this.OrderDao.Update(order);
            return rowCount;
        }
    }
}
