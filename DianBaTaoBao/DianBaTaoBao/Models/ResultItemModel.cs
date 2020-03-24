using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DianBaTaoBao.Models
{
    public class ResultItemModel
    {
        public string MetaTaobao月销量 { get; set; }


        public int? IntTaobao月销量 => ConvertHelper.ToInt(this.MetaTaobao月销量);

        public string DispTaobao月销量 => ConvertHelper.ToDispStr(IntTaobao月销量);

        public string MetaTaobao单价 { get; set; }

        public decimal? DecTaobao单价 => ConvertHelper.ToDecimal(this.MetaTaobao单价);

        public string DispTaobao单价 => ConvertHelper.ToDispStr(DecTaobao单价);
        public int Sn { get; set; }

        public string MetaDianba总销量 { get; set; }

        public int? IntDianba总销量 => ConvertHelper.ToInt(this.MetaDianba总销量);

        public string DispDianba总销量 => ConvertHelper.ToDispStr(this.IntDianba总销量);
        public string MetaDianba月销量 { get; set; }

        public int? IntDianba月销量 => ConvertHelper.ToInt(this.MetaDianba月销量);
        public string DispDianba月销量 => ConvertHelper.ToDispStr(this.IntDianba月销量);
        public string MetaDianba周销量 { get; set; }
        public int? IntDianba周销量 => ConvertHelper.ToInt(this.MetaDianba周销量);
        public string DispDianba周销量 => ConvertHelper.ToDispStr(this.IntDianba周销量);
        public string MetaDianba日销量 { get; set; }
        public int? IntDianba日销量 => ConvertHelper.ToInt(this.MetaDianba日销量);
        public string DispDianba日销量 => ConvertHelper.ToDispStr(this.IntDianba日销量);
        public string MetaDianba单价 { get; set; }

    }
}
