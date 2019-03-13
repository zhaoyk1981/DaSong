using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRGameConsole.Models
{
    public class OprationRecordModel
    {
        public AppModel App { get; set; }

        public DateTime? DateStarted { get; set; }

        public DateTime? DateFinished { get; set; }

        public int? LimitMinutes { get; set; }
    }
}
