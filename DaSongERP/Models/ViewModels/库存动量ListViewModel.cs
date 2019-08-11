using DaSongERP.Conditions;
using DaSongERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YK.Model;

namespace DaSongERP.ViewModels
{
    public class 库存动量ListViewModel : PagedListViewModel
    {
        public PagedList<库存动量Model> ModelList { get; set; }

        public 库存商品Model 库存商品 { get; set; }
    }
}
