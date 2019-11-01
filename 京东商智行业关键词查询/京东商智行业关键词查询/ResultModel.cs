using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 京东商智行业关键词查询
{
    public class ResultModel
    {

        public class ContentModel
        {

            public class ItemModel
            {
                public string value { get; set; }
                /// <summary>
                /// 较前一期
                /// </summary>
                public decimal? rate { get; set; }
            }

            /// <summary>
            /// 搜索点击指数
            /// </summary>
            public ItemModel SearchClickIndex { get; set; }
            /// <summary>
            /// 搜索指数
            /// </summary>
            public ItemModel SearchIndex { get; set; }
            /// <summary>
            /// 成交金额指数
            /// </summary>
            public ItemModel OrdAmtIndex { get; set; }
            /// <summary>
            /// 成交单量指数
            /// </summary>
            public ItemModel OrdNumIndex { get; set; }
            /// <summary>
            /// 成交转化率
            /// </summary>
            public ItemModel ConvertRate { get; set; }
            /// <summary>
            /// 点击率
            /// </summary>
            public ItemModel ClickRate { get; set; }
            /// <summary>
            /// 全网商品数
            /// </summary>
            public ItemModel CommodityNumber { get; set; }

            /// <summary>
            /// 潜力值
            /// </summary>
            public ItemModel Competition { get; set; }
        }

        public int length { get; set; }

        public ContentModel content { get; set; }

        public string message { get; set; }

        public int status { get; set; }
        /// <summary>
        /// 次优品类
        /// </summary>
        public string SuboptimalIndName { get; set; }
        /// <summary>
        /// 最优品类
        /// </summary>
        public string OptimalIndName { get; set; }
    }


}
