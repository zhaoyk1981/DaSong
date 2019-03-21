using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSC.Models
{
    public class 帐户Model
    {
        public string 钱包地址 { get; set; }

        public string 别名 { get; set; } = "匿名";

        //public bool 是返佣帐户 { get; set; }

        public string 登录密码 { get; set; }

        private string _资金密码;
        public string 资金密码
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this._资金密码))
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

        public string 显示帐号()
        {
            return string.IsNullOrEmpty(this.别名) ? this.钱包地址 : $"帐号{this.别名}, ";
        }
    }
}
