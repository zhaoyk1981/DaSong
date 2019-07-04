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
        public EditOrderViewModel GetEditOrderViewModel()
        {
            var vm = new EditOrderViewModel();
            vm.店铺DataSource = this.MetaDao.Get店铺();
            vm.淘宝账号DataSource = this.MetaDao.Get淘宝账号();
            return vm;
        }

        public int CreateOrder(OrderModel order)
        {
            order.ID = Guid.NewGuid();
            order.采购人ID = this.UserID;
            order.进货日期 = DateTime.Now;
            if (!string.IsNullOrEmpty(order.来快递单号))
            {
                order.发货时间 = DateTime.Now;
            }

            return this.OrderDao.CreateOrder(order);
        }

        public string GetProductImagesPath()
        {
            var p = HttpContext.Current.Server.MapPath("~/ProductImages");
            return p;
        }
    }
}
