using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaSongERP.Models
{
    public class 热销商品统计Model : Model
    {
        public string ID => $"{货号}_{规格}";
        public string 货号 { get; set; }

        public string 规格 { get; set; }

        public int? 总销量 { get; set; }

        public string Str总销量
        {
            get
            {
                return this.总销量.GetValueOrDefault().ToString();
            }
        }

        public int? 退货数量 { get; set; } = 0;

        public int? 订单数 { get; set; }

        public string Str订单数
        {
            get
            {
                return this.订单数.GetValueOrDefault().ToString();
            }
        }

        public string Thumbnails { get; set; }

        public int? 现货数量 { get; set; }

        public int? 在途数量 { get; set; }

        public int 虚拟数量
        {
            get
            {
                return 现货数量.GetValueOrDefault() + 在途数量.GetValueOrDefault();
            }
        }
    }
}
