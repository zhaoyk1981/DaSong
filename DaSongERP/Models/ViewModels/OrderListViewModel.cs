using DaSongERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YK.Model;

namespace DaSongERP.ViewModels
{
    public class OrderListViewModel : ViewModel
    {
        public string JD订单号 { get; set; }

        public string 来快递单号 { get; set; }
        public IList<OrderModel> Orders { get; set; }

        public OrderModel Condition { get; set; }
    }
}
