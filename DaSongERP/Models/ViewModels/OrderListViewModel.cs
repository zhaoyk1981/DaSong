using DaSongERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YK.Model;

namespace DaSongERP.ViewModels
{
    public class OrderListViewModel : PagedListViewModel
    {
        public PagedList<OrderModel> Orders { get; set; }
    }
}
