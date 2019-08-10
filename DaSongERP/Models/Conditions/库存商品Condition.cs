using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YK.Model;

namespace DaSongERP.Conditions
{
    public class 库存商品Condition : PagingCondition
    {
        public Guid? ID { get; set; }

        public string 货号 { get; set; }

        public string 规格 { get; set; }

        public string Name { get; set; }

        public string 仓库 { get; set; }

        public string 库位 { get; set; }

        public int? 现货数量 { get; set; }

        public int? 在途数量 { get; set; }

        public int? 虚拟数量 { get; set; }
    }
}
