using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDTopComment
{
    public class JDSearchResultModel
    {
        public string Keyword { get; set; }
        public int? ResultCount { get; set; }

        public IDictionary<string, int> ItemList { get; set; } = new Dictionary<string, int>();
    }
}
