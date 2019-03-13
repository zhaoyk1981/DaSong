using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRGameConsole.Models
{
    public class ViewModel
    {
        [JsonIgnore]
        public DateTime StartTime { get; set; } = DateTime.Now;
        [JsonIgnore]
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
            this.Desc = settings.Desc;
        }

        [JsonIgnore]
        public List<OperationRecordModel> RunningApps { get; set; } = new List<OperationRecordModel>();

        [JsonIgnore]
        public List<OperationRecordModel> RunApps { get; set; } = new List<OperationRecordModel>();

        public List<AppModel> AppList { get; set; } = new List<AppModel>();

        public string Desc { get; set; }

        public SettingsModel GetSettings()
        {
            var settings = new SettingsModel()
            {
                AppList = this.AppList,
                Desc = this.Desc
            };
            return settings;
        }
    }
}
