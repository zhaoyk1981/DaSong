using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaSongERP.Models
{
    public class MetaModel : Model
    {
        public Guid? ID { get; set; }

        public string Name { get; set; }

        public int? SN { get; set; }
    }
}
