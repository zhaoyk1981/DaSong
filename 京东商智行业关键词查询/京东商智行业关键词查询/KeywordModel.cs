using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 京东商智行业关键词查询
{
    public class KeywordModel
    {
        public string Id { get; set; }

        public string Keyword { get; set; }

        public bool Valid { get; set; }

        public IList<string> DataList { get; set; }

        public ResultItemModel 成交转化率 { get; set; } = new ResultItemModel();

        public ResultItemModel 成交金额指数 { get; set; } = new ResultItemModel();

        public ResultItemModel 搜索点击指数 { get; set; } = new ResultItemModel();

        public ResultItemModel 搜索指数 { get; set; } = new ResultItemModel();

        public ResultItemModel 成交单量指数 { get; set; } = new ResultItemModel();

        public ResultItemModel 全网商品数 { get; set; } = new ResultItemModel();

        public ResultItemModel 点击率 { get; set; } = new ResultItemModel();

        public ResultItemModel 潜力值 { get; set; } = new ResultItemModel();
    }
}
