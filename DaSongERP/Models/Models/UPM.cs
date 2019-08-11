using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaSongERP.Models
{
    [Flags]
    public enum UPM
    {
        管理 = 1,
        采购 = 2,
        跟进 = 4,
        电话 = 8,
        拆包 = 16,
        售后 = 32,
        客服 = 64,
        仓库_只读 = 128,
        仓库_读写 = 256
    }
}
