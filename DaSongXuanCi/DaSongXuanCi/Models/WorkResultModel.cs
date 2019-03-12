using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaSongXuanCi.Models
{
    public class WorkResultModel
    {
        public bool 成功 { get; set; }

        public string Message { get; set; }

        public Exception Exception { get; set; }
    }
}
