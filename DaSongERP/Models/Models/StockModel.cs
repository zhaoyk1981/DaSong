using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaSongERP.Models
{
    public class StockModel : Model
    {
        public Guid? ID { get; set; }

        public int? 库存数量 { get; set; }

        public int? 在途数量 { get; set; }
    }
}
