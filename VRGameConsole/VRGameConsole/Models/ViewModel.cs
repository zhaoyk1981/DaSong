using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRGameConsole.Models
{
    public class ViewModel : SettingsModel
    {
        public DateTime StartTime { get; set; } = DateTime.Now;
        public BackgroundWorker Worker { get; set; } = new BackgroundWorker()
        {
            WorkerReportsProgress = true,
            WorkerSupportsCancellation = true
        };

        public void Set(SettingsModel settings)
        {
            if (settings == null)
            {
                return;
            }

            this.AppList = settings.AppList;

        }

        public List<OperationRecordModel> RunningApps { get; set; } = new List<OperationRecordModel>();

        public List<OperationRecordModel> RunApps { get; set; } = new List<OperationRecordModel>();

    }
}
