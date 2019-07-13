using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaSongERP.Models
{
    public class OrderCountModel : Model
    {
        public int 未跟进 { get; set; }

        public int 未导入 { get; set; }

        public int 未拆包 { get; set; }

        public int 未完结售后 { get; set; }
    }
}
