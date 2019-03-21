using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSC.Models
{
    public class Order500Model
    {
        public class Result
        {
            public long date { get; set; }

            public long price { get; set; }

            public long amount { get; set; }

            public long tid { get; set; }

            public string side { get; set; }
        }

        public List<Result> result { get; set; }
    }
}
