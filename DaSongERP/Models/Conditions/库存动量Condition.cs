using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YK.Model;

namespace DaSongERP.Conditions
{
    public class 库存动量Condition : PagingCondition
    {
        public int? ID { get; set; }

        public DateTime? DateCreated { get; set; }

        public Guid? 库存商品ID { get; set; }

        public int? 现货数量 { get; set; }

        public int? 在途数量 { get; set; }

        public Guid? OrderID { get; set; }

        public string Remark { get; set; }

        public Guid? UserID { get; set; }
    }
}
