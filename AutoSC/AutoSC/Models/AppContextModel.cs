using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSC.Models
{
    public class AppContextModel
    {
        public BackgroundWorker Worker { get; set; }

        private IWebDriver _WebDriver;

        public IWebDriver WebDriver
        {
            get
            {
                return this._WebDriver;
            }
            set
            {
                this._WebDriver = value;
            }
        }

        public DateTime 程序开始时间 { get; set; }

        public DateTime 操作开始时间 { get; set; }

        public 交易记录Model 交易记录 { get; set; }

        public 出价表Model 出价表 { get; set; }

        public bool 零售模式 => false;

        public DateTime? 暂停交易至 { get; set; }

        public 帐户Model 当前帐户 { get; set; }
        public int? 起始完成度 { get; set; }

        public decimal? 起始利润 { get; set; }
        public string 运行状态 { get; set; }
        public decimal? 涨停价 { get; set; }

        public decimal? 跌停价 { get; set; }

        public int 刷新交易记录指数 { get; set; }
        
        public bool 刷新交易记录
        {
            get
            {
                return this.刷新交易记录指数 >= 15;
            }
        }

    }
}
