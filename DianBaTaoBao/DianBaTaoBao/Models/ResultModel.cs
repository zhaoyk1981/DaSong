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


    }
}
