using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRGameConsole.Models
{
    public class OperationRecordModel
    {
        public OperationRecordModel()
        {

        }
        public OperationRecordModel(Process p, List<AppModel> appList)
        {
            this.ProcessID = p.Id;
            this.App = appList.Single(m => String.Compare(m.ProcessName, p.ProcessName, true) == 0);
            this.DateStarted = p.StartTime;
        }

        public AppModel App { get; set; } = new AppModel();

        public int? ProcessID { get; set; }

        public DateTime? DateStarted { get; set; }

        public DateTime? DateFinished { get; set; }

        public int? LimitMinutes { get; set; }

        public bool Saved { get; set; }

        public bool? Expired
        {
            get
            {
                if (this.DateStarted.HasValue && this.LimitMinutes.HasValue)
                {
                    return DateTime.Now > this.DateStarted.Value.AddMinutes(this.LimitMinutes.Value);
                }

                return null;
            }
        }

        public TimeSpan? CountDown
        {
            get
            {
                if (this.DateStarted.HasValue && this.LimitMinutes.HasValue)
                {
                    return this.DateStarted.Value.AddMinutes(this.LimitMinutes.Value) - DateTime.Now;
                }

                return null;
            }
        }

        public void Set(OperationRecordModel p)
        {
            this.ProcessID = p.ProcessID;
            this.DateStarted = p.DateStarted;
        }
    }
}
