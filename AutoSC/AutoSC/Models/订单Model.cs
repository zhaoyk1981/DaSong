using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSC.Models
{
    public class 订单Model
    {
        public 订单Model()
        {

        }

        public 订单Model(Order500Model.Result data)
        {
            this.Time = new DateTime(1970, 1, 1, 8, 0, 0).AddMilliseconds(data.date);
            this.单价 = data.price / 100000000m;
            this.数量 = Convert.ToInt32(Math.Floor(data.amount / 100000000m));
            this.买入 = string.Compare(data.side, "BUY", true) != 0; // 传入的数据可能是反的。
        }
        [JsonIgnore]
        public long Tid { get; set; }
        [JsonIgnore]
        public DateTime Time { get; set; }
        public string StrTime
        {
            get
            {
                return this.Time.ToString("HH:mm:ss");
            }
        }

        public 价格策略Enum 价格策略 { get; set; }
        public bool 买入 { get; set; }
        public int 数量 { get; set; }
        public decimal 单价 { get; set; }

        public decimal 利润
        {
            get
            {
                if (this.买入 || this.BuyOrder == null || this.BuyOrder.单价 == 0)
                {
                    return 0m;
                }

                return (this.单价 - this.BuyOrder.单价) * this.数量;
            }
        }

        public decimal Price
        {
            get
            {
                return this.单价 * this.数量;
            }
        }

        public decimal Charge
        {
            get
            {
                if (this.买入)
                {
                    return 0m;
                }

                return this.Price * 0.001m;
            }
        }

        [JsonIgnore]
        public 出价表Model TradeInfo { get; set; }

        public Object TradeJson
        {
            get
            {
                return this.TradeInfo?.ToJsonObj();
            }
        }

        private 订单Model _BuyOrder;
        public 订单Model BuyOrder
        {
            get
            {
                if (!this.买入)
                {
                    return _BuyOrder;
                }
                return null;
            }
            set
            {
                if (!this.买入)
                {
                    this._BuyOrder = value;
                }
            }
        }
    }
}
