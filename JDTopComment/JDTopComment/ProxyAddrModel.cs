using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDTopComment
{
    public class ProxyAddrModel
    {
        public string IpAddr { get; set; }

        public string Port { get; set; }

        public string Url => $"{IpAddr}:{Port}";

        public bool IsUsing { get; set; }
    }
}
