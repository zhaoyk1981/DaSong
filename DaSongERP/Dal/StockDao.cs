using DaSongERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YK;

namespace DaSongERP.Dal
{
    public class StockDao : Dao
    {
        public StockModel Get库存(string 货号)
        {
            var cmd = ProcCommands.sp_Get库存().SetParameterValues(new
            {
                货号 = 货号
            });
            var list = DBHelper.ExecuteEntityList<StockModel>(cmd);
            return list.FirstOrDefault();
        }
    }
}
