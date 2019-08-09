using DaSongERP.Conditions;
using DaSongERP.Models;
using DaSongERP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YK;
using YK.Model;
using YK.Mappers;

namespace DaSongERP.Dal
{
    public class 统计Dao : Dao
    {
        public 拆包审单统计ViewModel 统计拆包审单数量()
        {
            var vm = new 拆包审单统计ViewModel();
            var cmd = ProcCommands.sp_统计拆包审单数量();
            var ds = DBHelper.ExecuteDataSet(cmd);
            vm.ListByUser = DbMapperUtil.Map<统计项Model<int>>(ds.Tables[0]);
            vm.ListByStatus = DbMapperUtil.Map<统计项Model<int>>(ds.Tables[1]);
            return vm;
        }
    }
}
