using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaSongERP.Dal
{
    [Flags]
    public enum CellStatus
    {
        None = 0,
        Exists = 1,
        Merged = 2
    }
}
