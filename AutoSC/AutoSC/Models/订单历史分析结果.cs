using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSC.Models
{
    public class 订单历史分析结果
    {
        public int 订单数 { get; set; }

        public int 上涨数 { get; set; }

        public int 下跌数 { get; set; }

        public decimal 上涨幅度 { get; set; }

        public decimal 下跌幅度 { get; set; }

        public decimal 起始单价 { get; set; }

        public decimal 结束单价 { get; set; }

        public List<decimal> 单价记录 { get; set; } = new List<decimal>();

        public int 连续上涨数 => this.下跌数 > 0 ? 0 : this.上涨数;

        public int 连续下跌数 => this.上涨数 > 0 ? 0 : this.下跌数;
    }
}
