using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSC.Models
{
    public class 设置Model
    {
        public string 钱包地址 { get; set; }

        public string 登录密码 { get; set; }

        private string _资金密码;

        public string 资金密码
        {
            get
            {
                if (this.不使用资金密码 || string.IsNullOrEmpty(this._资金密码))
                {
                    return this.登录密码;
                }

                return this._资金密码;
            }
            set
            {
                this._资金密码 = value;
            }
        }

        public bool 不使用资金密码 { get; set; }

        public 操作Enum 当前操作 { get; set; }

        public 浏览器Enum 当前浏览器 { get; set; }

        public string 激活码 { get; set; }

        public DateTime? 开始交易时间 { get; set; }

        public DateTime? 结束交易时间 { get; set; }

        public decimal? 较大亏损 { get; set; }

        public int? 暂停分钟数 { get; set; }

        public decimal? 结束手数 { get; set; }

        public const string 文件名 = "设置.json";

        public bool 今天是交易日
        {
            get
            {
                return DateTime.Now.DayOfWeek != DayOfWeek.Sunday;
            }
        }

        public DateTime 开盘时间
        {
            get
            {
                return DateTime.Now.Date.AddDays(this.今天是交易日 ? 0 : 1).AddHours(10);
            }
        }

        public DateTime 闭盘时间
        {
            get
            {
                return this.开盘时间.AddHours(12);
            }
        }

        public decimal? 仅卖出代币单价下限 { get; set; }

        public decimal? 仅卖出EHE单价下限 { get; set; }

        public int? 保留EHE数量 { get; set; }

        public bool 购买EHE { get; set; } = true;
    }
}
