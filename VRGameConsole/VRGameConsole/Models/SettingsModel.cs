using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRGameConsole.Models
{
    public class SettingsModel
    {
        public List<AppModel> AppList { get; set; }

        public DateTime StartTime { get; set; } = DateTime.Now;
    }
}
