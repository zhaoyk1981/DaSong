using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DianBaTaoBao.Models
{
    public class ResultItemModel
    {
        public string MetaTaobaoUrl { get; set; }
        public string MetaTaobao月销量 { get; set; }


        public int? IntTaobao月销量 => ConvertHelper.ToInt2(this.MetaTaobao月销量);

        public string MetaTaobao单价 { get; set; }

        public decimal? DecTaobao单价 => ConvertHelper.ToDecimal(this.MetaTaobao单价);

        public int Sn { get; set; }

        public string MetaDianba商品Id { get; set; }

        public string MetaDianba商品Url
        {
            get
            {
                if (!string.IsNullOrEmpty(MetaDianba商品Id))
                {
                    return $"http://app.yangkeduo.com/goods.html?goods_id={MetaDianba商品Id}";
                }

                return string.Empty;
            }
        }

        public string MetaDianba总销量 { get; set; }

        public int? IntDianba总销量 => ConvertHelper.ToInt2(this.MetaDianba总销量);

        public string MetaDianba月销量 { get; set; }

        public int? IntDianba月销量 => ConvertHelper.ToInt2(this.MetaDianba月销量);
        public string MetaDianba周销量 { get; set; }
        public int? IntDianba周销量 => ConvertHelper.ToInt2(this.MetaDianba周销量);
        public string MetaDianba日销量 { get; set; }
        public int? IntDianba日销量 => ConvertHelper.ToInt2(this.MetaDianba日销量);
        public string MetaDianba单价 { get; set; }

        public int? 月销量差额
        {
            get
            {
                if (IntTaobao月销量.HasValue && IntDianba月销量.HasValue)
                {
                    return IntTaobao月销量.Value - IntDianba月销量.Value;
                }

                return null;
            }
        }

        public bool HasError { get; set; } = true;

        public bool Completed { get; set; }
    }
}
