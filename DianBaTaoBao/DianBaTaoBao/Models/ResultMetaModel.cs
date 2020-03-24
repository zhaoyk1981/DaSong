using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DianBaTaoBao.Models
{
    public class ResultMetaModel
    {
        public string Keyword { get; set; }
        public IList<ResultItemMetaModel> List { get; set; } = new List<ResultItemMetaModel>();
    }
}
