using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaSongERP.Models
{
    public class MetaModel<T> : Model where T : struct
    {
        public T? ID { get; set; }

        public string Name { get; set; }

        public int? SN { get; set; }
    }
}
