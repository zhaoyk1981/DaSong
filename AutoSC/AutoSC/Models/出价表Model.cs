using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSC.Models
{
    public class 出价表Model
    {
        public List<出价Model> Buy { get; set; }

        public List<出价Model> Sell { get; set; }
        [JsonIgnore]
        public List<订单Model> Orders { get; set; }
        [JsonIgnore]
        public bool Enabled
        {
            get
            {

                return (this.Orders?.Count).GetValueOrDefault() >= 1 && (this.Buy?.Count).GetValueOrDefault() >= 1;
            }
        }
        [JsonIgnore]
        public decimal? FirstBuyPrice => this.Buy.FirstOrDefault().Price;

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public decimal? Top4BuyPrice => this.Buy.Take(4).Sum(m => m.Price);

        private const int 波动检测数量 = 4;
        [JsonIgnore]
        public bool 买家价格波动
        {
            get
            {
                var n = 0m;
                for (var i = 1; i < 波动检测数量; i++)
                {
                    n += this.Buy.ElementAt(i).单价 - this.Buy.ElementAt(i - 1).单价;
                }

                return n > 波动检测数量 * 0.002m;
            }
        }

        public bool 检测买家价格波动(int top, decimal diff)
        {
            var n = 0m;
            for (var i = 1; i < top; i++)
            {
                n += this.Buy[i - 1].单价 - this.Buy[i].单价;
            }

            return n > diff;
        }

        public long 买家数量(int top, int skip = 0)
        {
            if (this.Buy.Count < top + skip)
            {
                return 0;
            }

            return this.Buy.Skip(skip).Take(top).Sum(m => m.Quantity);
        }
        [JsonIgnore]
        public long 买1数量 => this.Buy.FirstOrDefault().Quantity;
        [JsonIgnore]
        public long 买2数量 => this.Buy.ElementAt(1).Quantity;
        [JsonIgnore]
        public long 买3数量 => this.Buy.ElementAt(2).Quantity;
        [JsonIgnore]
        public long 卖1数量 => this.Sell.FirstOrDefault().Quantity;

        public long 买前几数量(int top) => this.Buy.Take(top).Where(m => m.Quantity % 100 != 0).Sum(m => m.Quantity);

        public decimal 买卖前几数量比较(int top)
        {
            var bq = this.Buy.Take(top).Sum(m => m.Quantity);
            var sq = this.Sell.Take(top).Sum(m => m.Quantity);
            if (sq == 0)
            {
                return 0;
            }

            var r = Convert.ToDecimal(bq) / sq;
            return r;
        }
        [JsonIgnore]
        public decimal 买1单价 => this.Buy.First().单价;

        public decimal 买2单价 => this.Buy.ElementAt(1).单价;
        [JsonIgnore]
        public decimal 卖1单价 => this.Sell.First().单价;
        [JsonIgnore]
        public decimal 买1总价 => this.Buy.First().Price;
        [JsonIgnore]
        public decimal 卖1总价 => this.Sell.First().Price;

        public long 卖前几数量(int top) => this.Sell.Take(top).Where(m => m.Quantity % 100 != 0).Sum(m => m.Quantity);
        [JsonIgnore]
        public int 近期订单数 => this.Orders.Count(m => m.Time >= DateTime.Now.AddSeconds(45));
        [JsonIgnore]
        public int 近期买入订单数 => this.Orders.Count(m => m.买入 && m.Time >= DateTime.Now.AddSeconds(45));
        [JsonIgnore]
        public bool 大跌特征
        {
            get
            {
                var chkPont2_1 = this.买卖前几数量比较(3) < 1m;
                var chkPont2_2 = this.买前几数量(3) < 6000;
                return chkPont2_1 && chkPont2_2;
            }
        }

        public 订单历史分析结果 分析成交订单(double seconds = 45)
        {
            var result = new 订单历史分析结果();
            var t = DateTime.Now.AddSeconds(-seconds);
            var ods = this.Orders.Where(m => m.买入 && m.Time >= t).OrderBy(m => m.Time).ToList();
            if (ods.Count == 0)
            {
                return result;
            }

            decimal last单价 = ods.First().单价;
            result.起始单价 = last单价;
            for (var i = 1; i < ods.Count; i++)
            {
                result.单价记录.Add(ods[i].单价);
                var 差价 = ods[i].单价 - last单价;
                if (差价 > 0)
                {
                    if (result.下跌数 > 0)
                    {
                        break;
                    }

                    result.上涨数++;
                    result.上涨幅度 += 差价;
                }
                else if (差价 < 0)
                {
                    if (result.上涨数 > 0)
                    {
                        break;
                    }

                    result.下跌数++;
                    result.下跌幅度 += 差价;
                }

                last单价 = ods[i].单价;
            }

            return result;
        }

        public int 买家数量和(int skip, int take)
        {
            return this.Buy.Skip(skip).Take(take).Sum(m => m.Quantity);
        }

        public 订单Model 最新买入订单()
        {
            if (this.Orders.Count == 0)
            {
                return null;
            }

            return this.Orders.Where(m => m.买入).OrderByDescending(m => m.Time).FirstOrDefault();
        }

        public 订单Model 最新卖出订单()
        {
            if (this.Orders.Count == 0)
            {
                return null;
            }

            return this.Orders.Where(m => !m.买入).OrderByDescending(m => m.Time).FirstOrDefault();
        }

        public object ToJsonObj()
        {
            return new
            {
                买家 = this.Buy.Select((m, i) => $"买{i + 1},单价:{m.单价.ToString("f3")},数量:{m.Quantity},价格:{m.Price.ToString("f3")};").ToArray(),
                卖家 = this.Sell.Select((m, i) => $"卖{i + 1},单价:{m.单价.ToString("f3")},数量:{m.Quantity},价格:{m.Price.ToString("f3")};").ToArray()
            };
        }
    }
}
