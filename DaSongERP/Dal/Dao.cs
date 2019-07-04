using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YK.Utils;

namespace DaSongERP.Dal
{
    public class Dao
    {
        protected DBHelper DBHelper { get; set; } = new DBHelper("DaSongERP");
    }
}
