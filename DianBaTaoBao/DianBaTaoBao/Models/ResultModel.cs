using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DianBaTaoBao.Models
{
    public class ResultModel
    {
        public string Keyword { get; set; }
        public IList<ResultItemModel> List { get; set; } = new List<ResultItemModel>();

        public decimal? AvgTb单价
        {
            get
            {
                var lst = List.Where(m => m.DecTaobao单价.HasValue).ToList();
                if(lst.Count == 0)
                {
                    return null;
                }

                return lst.Average(m => m.DecTaobao单价.Value);
            }
        }

        public object DispAvgTb单价 => ConvertHelper.ToDispStr(AvgTb单价);

        public int? AvgTb月销量
        {
            get
            {
                var lst = List.Where(m => m.IntTaobao月销量.HasValue).ToList();
                if(lst.Count == 0)
                {
                    return null;
                }

                return Convert.ToInt32(lst.Average(m => m.IntTaobao月销量.Value));
            }
        }

        public object DispAvgTb月销量 => ConvertHelper.ToDispStr(AvgTb月销量);

        public int? AvgDb月销量
        {
            get
            {
                var lst = List.Where(m => m.IntDianba月销量.HasValue).ToList();
                if (lst.Count == 0)
                {
                    return null;
                }

                return Convert.ToInt32(lst.Average(m => m.IntDianba月销量.Value));
            }
        }

        public object DispAvgDb月销量 => ConvertHelper.ToDispStr(AvgDb月销量);

        public int? AvgDb日销量
        {
            get
            {
                var lst = List.Where(m => m.IntDianba日销量.HasValue).ToList();
                if (lst.Count == 0)
                {
                    return null;
                }

                return Convert.ToInt32(lst.Average(m => m.IntDianba日销量.Value));
            }
        }

        public object DispAvgDb日销量 => ConvertHelper.ToDispStr(AvgDb日销量);

        public int? AvgDb周销量
        {
            get
            {
                var lst = List.Where(m => m.IntDianba周销量.HasValue).ToList();
                if (lst.Count == 0)
                {
                    return null;
                }

                return Convert.ToInt32(lst.Average(m => m.IntDianba周销量.Value));
            }
        }

        public object DispAvgDb周销量 => ConvertHelper.ToDispStr(AvgDb周销量);

        public int? AvgDb总销量
        {
            get
            {
                var lst = List.Where(m => m.IntDianba总销量.HasValue).ToList();
                if (lst.Count == 0)
                {
                    return null;
                }

                return Convert.ToInt32(lst.Average(m => m.IntDianba总销量.Value));
            }
        }

        public object DispAvgDb总销量 => ConvertHelper.ToDispStr(AvgDb总销量);
    }
}
