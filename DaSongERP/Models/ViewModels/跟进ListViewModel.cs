using DaSongERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YK;
using YK.Model;

namespace DaSongERP.ViewModels
{
    public class 跟进ListViewModel : PagedListViewModel
    {
        public PagedList<OrderModel> Orders { get; set; }
    }
}
