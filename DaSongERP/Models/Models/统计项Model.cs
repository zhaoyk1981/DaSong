using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaSongERP.Models
{
    public class 统计项Model<T> : Model where T : struct
    {
        public string Name { get; set; }

        public T Count { get; set; }
    }
}
