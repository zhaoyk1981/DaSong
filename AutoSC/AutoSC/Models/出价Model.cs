using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSC.Models
{
    public class 出价Model
    {
        public 出价Model(List<long> data, bool isBuy)
        {
            this.买入 = isBuy;
            this.单价 = data[0] / 100000000m;
            this.Quantity = Convert.ToInt32(data[1] / 100000000);
        }
        public bool 买入 { get; set; }
        public decimal 单价 { get; set; }

        public int Quantity { get; set; }

        public decimal Price => this.单价 * this.Quantity;
    }
}
