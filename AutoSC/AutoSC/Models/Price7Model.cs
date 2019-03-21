using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSC.Models
{
    public class Price7Model
    {
        public class Result
        {
            public string market { get; set; }

            public List<List<long>> ask { get; set; }

            public List<List<long>> bid { get; set; }
        }

        public Result result { get; set; }
    }
}
