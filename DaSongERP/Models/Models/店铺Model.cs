using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaSongERP.Models
{
    public class 店铺Model : Model
    {
        public Guid? ID { get; set; }

        public string Name { get; set; }

        public string Prefix { get; set; }
    }
}
