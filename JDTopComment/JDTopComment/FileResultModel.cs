using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDTopComment
{
    public class FileResultModel
    {
        public string FileName { get; set; }

        public IList<JDSearchResultModel> List { get; set; } = new List<JDSearchResultModel>();

        public bool Exported { get; set; }


    }
}
