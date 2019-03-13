using Newtonsoft.Json;
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

        public string Desc { get; set; }

    }
}
