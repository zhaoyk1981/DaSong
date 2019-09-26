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
    public class 拆包审单ListViewModel : PagedListViewModel
    {
        public PagedList<OrderModel> Orders { get; set; }

        public IList<MetaModel<Guid>> 中转仓DataSource { get; set; }

        public IList<统计项Model<int>> 每日未拆包审单统计 { get; set; }

        public DateTime? 进货日期 { get; set; }

        public bool? 在途待发 { get; set; }

        public string 货号 { get; set; }
    }
}
