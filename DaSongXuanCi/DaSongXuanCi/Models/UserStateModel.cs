using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaSongXuanCi.Models
{
    public class UserStateModel
    {
        public UserStateModel()
        {

        }
        public UserStateModel(string msg, Exception ex = null)
        {
            this.Message = msg;
            this.Exception = ex;
        }

        public string Message { get; set; }

        public Exception Exception { get; set; }

        public 操作? 操作 { get; set; }

        public bool 需要手动登录 { get; set; }
    }
}
