using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSC.Models
{
    public class 交易记录Model
    {
        public decimal? EHE单价 { get; set; }

        public decimal? THSC单价 { get; set; }
        public List<订单Model> 订单 { get; set; } = new List<订单Model>();

        public decimal TotalSellTradePrice
        {
            get
            {
                try
                {
                    if ((this.订单?.Count(m => !m.买入)).GetValueOrDefault() == 0)
                    {
                        return 0m;
                    }

                    return this.订单.Where(m => !m.买入).Sum(m => m.Price);
                }
                catch
                {
                    return 0m;
                }
            }
        }

        public decimal TotalBuyTradePrice
        {
            get
            {
                try
                {
                    if ((this.订单?.Count(m => m.买入)).GetValueOrDefault() == 0)
                    {
                        return 0m;
                    }

                    return this.订单.Where(m => m.买入).Sum(m => m.Price);
                }
                catch
                {
                    return 0m;
                }
            }
        }

        public int CompletedPer
        {
            get
            {
                if (this.EHE单价.HasValue)
                {
                    return Convert.ToInt32(Math.Floor(this.TotalCharge * 100 / (200m / this.EHE单价.Value)));
                }
                else
                {
                    return Math.Min(Convert.ToInt32(Math.Floor(this.总交易手数 * 100m / 11m)), 100);
                }
            }
        }

        public decimal 预计手数
        {
            get
            {
                if (!this.THSC单价.HasValue || !this.EHE单价.HasValue)
                {
                    return 0;
                }

                return (200 / this.EHE单价.Value) * 1000m / this.THSC单价.Value / 3000m;
            }
        }

        public decimal TotalCharge
        {
            get
            {
                if ((this.订单?.Count).GetValueOrDefault() == 0)
                {
                    return 0m;
                }

                return this.订单.Sum(m => m.Charge);
            }
        }

        public bool IsTaskCompleted
        {
            get
            {
                if (this.预计手数 > 0m)
                {
                    return this.总交易手数 > Math.Floor(this.预计手数) + 0.1m;
                }
                else
                {
                    return false;
                }
            }
        }

        public int 总卖出量
        {
            get
            {
                if (this.订单.Count == 0)
                {
                    return 0;
                }

                var sell = this.订单.Where(m => !m.买入).Sum(m => m.数量);
                return sell;
            }
        }

        public decimal 利润 => this.订单.Count > 0 ? this.订单.Sum(m => m.利润) : 0m;
        public decimal 总利润
        {
            get
            {
                if (this.订单.Count == 0 || this.订单.Count(m => m.买入) == 0 || this.订单.Count(m => !m.买入) == 0)
                {
                    return 0m;
                }

                var sell = this.订单.Where(m => !m.买入).Sum(m => m.Price);
                var buy = this.订单.Where(m => m.买入).Sum(m => m.Price);
                var firstSell = this.当日首次卖出金额;
                var lastBuy = this.最新买入订单金额;

                var t = sell - firstSell - (buy - lastBuy);
                if (Math.Abs(t) > 300)
                {

                }

                return t;
            }
        }

        public decimal 总交易手数
        {
            get
            {
                return Math.Min(this.订单.Where(m => !m.买入).Sum(m => m.数量), this.订单.Where(m => m.买入).Sum(m => m.数量)) / 3000m;
            }
        }

        public decimal 最新买入订单金额
        {
            get
            {
                if (this.订单.Count == 0 || this.订单.Count(m => !m.买入) == 0)
                {
                    return 0m;
                }

                var p = 0m;
                var list = this.订单.OrderByDescending(m => m.Time).ToList();
                foreach (var od in list)
                {
                    if (!od.买入)
                    {
                        break;
                    }

                    p += od.Price;
                }

                return p;
            }
        }

        public int 最新买入数量
        {
            get
            {
                if (this.订单.Count == 0 || this.订单.Count(m => m.买入) == 0 || this.订单.Count(m => !m.买入) == 0)
                {
                    return 0;
                }

                var p = 0;
                var list = this.订单.OrderByDescending(m => m.Time).ToList();
                foreach (var od in list)
                {
                    if (!od.买入)
                    {
                        break;
                    }

                    p += od.数量;
                }

                return p;
            }
        }

        public decimal 未卖出的代币数量
        {
            get
            {
                if (this.订单.Count == 0)
                {
                    return 0L;
                }

                var p = 0m;
                var list = this.订单.OrderByDescending(m => m.Time).ToList();
                foreach (var od in list)
                {
                    if (!od.买入)
                    {
                        break;
                    }

                    p += od.数量;
                }

                return p;
            }
        }

        public decimal 当日首次卖出金额
        {
            get
            {
                if (this.订单.Count == 0 || this.订单.Count(m => m.买入) == 0)
                {
                    return 0m;
                }

                var startSellPrice = 0m;
                var list = this.订单.OrderBy(m => m.Time).ToList();
                foreach (var o in list)
                {
                    if (o.买入)
                    {
                        break;
                    }

                    startSellPrice += o.Price;
                }

                return startSellPrice;
            }
        }

        public int 当日首次卖出数量
        {
            get
            {
                if (this.订单.Count == 0 || this.订单.Count(m => m.买入) == 0)
                {
                    return 0;
                }

                var startSellQty = 0;
                var list = this.订单.OrderBy(m => m.Time).ToList();
                foreach (var o in list)
                {
                    if (o.买入)
                    {
                        break;
                    }

                    startSellQty += o.数量;
                }

                return startSellQty;
            }
        }

        public 订单Model 最新买入订单()
        {
            if (this.订单.Count == 0)
            {
                return null;
            }

            return this.订单.Where(m => m.买入).OrderByDescending(m => m.Time).FirstOrDefault();
        }

        public void AddOrder(订单Model order)
        {
            this.订单.Insert(0, order);
            this.订单 = this.订单.OrderByDescending(m => m.Time).ToList();
        }

        public bool IsToday
        {
            get
            {
                if (this.订单.Count == 0)
                {
                    return true;
                }

                return !this.订单.Any(m => m.Time.Date < DateTime.Now.Date);
            }
        }
    }
}
