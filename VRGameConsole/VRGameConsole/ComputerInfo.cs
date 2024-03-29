﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRGameConsole
{
    public class ComputerInfo
    {
        public string CpuId { get; set; }

        public long DateStart { get; set; }

        public long DateEnd { get; set; }

        public long Passed { get; set; }

        public string RandomKey { get; set; } = Guid.NewGuid().ToString();
    }
}
