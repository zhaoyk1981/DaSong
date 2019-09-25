using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YK.Model;

namespace DaSongERP.Models
{
    public class 库存商品PagedList : PagedList<库存商品Model>
    {
        public 库存商品PagedList(PagingCondition condition = null, DataSet ds = null) : base(condition, ds)
        {
        }

        public int? 现货数量 { get; set; }

        public int? 在途数量 { get; set; }
    }
}
