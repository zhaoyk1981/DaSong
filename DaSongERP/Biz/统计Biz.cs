using DaSongERP.Conditions;
using DaSongERP.Models;
using DaSongERP.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using YK.Model;

namespace DaSongERP.Biz
{
    public class 统计Biz : Biz
    {
        public 拆包审单统计ViewModel 统计拆包审单数量()
        {
            return this.统计Dao.统计拆包审单数量();
        }
    }
}
