using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YK.Enums
{
    public enum DataOperationResult : ulong
    {
        None = 0ul,
        Success = 2ul ^ 1,
        Warning = 2ul ^ 11,
        Failed = 2ul ^ 31
    }
}
