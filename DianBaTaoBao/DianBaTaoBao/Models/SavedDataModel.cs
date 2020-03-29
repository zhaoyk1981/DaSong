using DianBaTaoBao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DianBaTaoBao.Models
{
    public class SavedDataModel
    {
        public IDictionary<string, IList<KeywordModel>> KeywordsDict { get; set; }

        public IDictionary<string, IList<ResultModel>> TaobaoResult { get; set; } = new Dictionary<string, IList<ResultModel>>();

        public IDictionary<string, IList<ResultModel>> DianbaResult { get; set; } = new Dictionary<string, IList<ResultModel>>();
    }
}
