using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaSongERP.Conditions
{
    public class 销售统计Condition
    {
        public DateTime? DateStart { get; set; }

        public DateTime? DateEnd { get; set; }

        public decimal? 运费 { get; set; }

        public string DateType { get; set; }
    }
}
