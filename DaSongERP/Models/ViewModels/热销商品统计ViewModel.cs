using DaSongERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YK.Model;

namespace DaSongERP.ViewModels
{
    public class 热销商品统计ViewModel : PagedListViewModel
    {
        public string 货号 { get; set; }

        public DateTime? DateStart { get; set; }

        public DateTime? DateEnd { get; set; }

        public PagedList<热销商品统计Model> List { get; set; }
    }
}
