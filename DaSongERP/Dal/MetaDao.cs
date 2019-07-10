using DaSongERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaSongERP.Dal
{
    public class MetaDao : Dao
    {
        public IList<MetaModel<Guid>> Get店铺()
        {
            var cmd = ProcCommands.sp_Get店铺();
            var list = DBHelper.ExecuteEntityList<MetaModel<Guid>>(cmd);
            return list;
        }

        public IList<MetaModel<Guid>> Get审单操作()
        {
            var cmd = ProcCommands.sp_Get审单操作();
            var list = DBHelper.ExecuteEntityList<MetaModel<Guid>>(cmd);
            return list;
        }

        public IList<MetaModel<Guid>> Get售后操作()
        {
            var cmd = ProcCommands.sp_Get售后操作();
            var list = DBHelper.ExecuteEntityList<MetaModel<Guid>>(cmd);
            return list;
        }

        public IList<MetaModel<Guid>> Get售后原因()
        {
            var cmd = ProcCommands.sp_Get售后原因();
            var list = DBHelper.ExecuteEntityList<MetaModel<Guid>>(cmd);
            return list;
        }

        public IList<MetaModel<Guid>> Get淘宝账号()
        {
            var cmd = ProcCommands.sp_Get淘宝账号();
            var list = DBHelper.ExecuteEntityList<MetaModel<Guid>>(cmd);
            return list;
        }
    }
}
