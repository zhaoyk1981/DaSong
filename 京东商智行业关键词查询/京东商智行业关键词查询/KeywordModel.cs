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

        public IList<string> DataList { get; set; }
    }
}
