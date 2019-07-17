using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaSongERP.Models
{
    public class 快递Model : Model
    {
        public int? ID { get; set; }

        public int? SN { get; set; }

        public string Name { get; set; }

        public string GroupLetter { get; set; }

        public string NameWithGroup
        {
            get
            {
                if (string.IsNullOrEmpty(GroupLetter))
                {
                    return Name;
                }

                return $"{GroupLetter} - {Name}";
            }
        }
    }
}
