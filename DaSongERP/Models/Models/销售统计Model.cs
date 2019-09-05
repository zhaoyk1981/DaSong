using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaSongERP.Models
{
    public class 销售统计Model : Model
    {
        public int? 总订单数 { get; set; }

        public string Str总订单数
        {
            get
            {
                return 总订单数.GetValueOrDefault().ToString();
            }
        }

        public int? 有效订单数 { get; set; }

        public string Str有效订单数
        {
            get
            {
                return 有效订单数.GetValueOrDefault().ToString();
            }
        }

        public decimal? 总销售额 { get; set; }

        public string Str总销售额
        {
            get
            {
                return this.总销售额.GetValueOrDefault().ToString("c2");
            }
        }

        public decimal? 有效销售额 { get; set; }

        public string Str有效销售额
        {
            get
            {
                return this.有效销售额.GetValueOrDefault().ToString("c2");
            }
        }

        public decimal? 总毛利 { get; set; }

        public string Str总毛利
        {
            get
            {
                return this.总毛利.GetValueOrDefault().ToString("c2");
            }
        }

        public decimal? 有效毛利 { get; set; }

        public string Str有效毛利
        {
            get
            {
                return this.有效毛利.GetValueOrDefault().ToString("c2");
            }
        }
    }
}
