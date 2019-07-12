using DaSongERP.Conditions;
using DaSongERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YK.Model;
using YK;

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

        public PagedList<MetaModel<Guid>> Get审单操作List(MetaCondition condition)
        {
            var cmd = ProcCommands.sp_审单操作List().SetParameterValues(condition);
            var dataSet = DBHelper.ExecuteDataSet(cmd);
            var pagedList = new PagedList<MetaModel<Guid>>(condition, dataSet);
            return pagedList;
        }

        public int Create审单操作(MetaModel<Guid> meta)
        {
            var cmd = ProcCommands.sp_Create审单操作().SetParameterValues(meta);
            var rowCount = (int)DBHelper.ExecuteScalar(cmd);
            return rowCount;
        }

        public int Update审单操作(MetaModel<Guid> meta)
        {
            var cmd = ProcCommands.sp_Update审单操作().SetParameterValues(meta);
            var rowCount = (int)DBHelper.ExecuteScalar(cmd);
            return rowCount;
        }

        public int Delete审单操作(Guid id)
        {
            var cmd = ProcCommands.sp_Delete审单操作().SetParameterValues(new
            {
                ID = id
            });
            var rowCount = (int)DBHelper.ExecuteScalar(cmd);
            return rowCount;
        }

        public MetaModel<Guid> Get审单操作By(Guid id)
        {
            var cmd = ProcCommands.sp_Get审单操作ByID().SetParameterValues(new
            {
                ID = id
            });

            return DBHelper.ExecuteEntityList<MetaModel<Guid>>(cmd).FirstOrDefault();
        }


        public PagedList<MetaModel<Guid>> Get售后操作List(MetaCondition condition)
        {
            var cmd = ProcCommands.sp_售后操作List().SetParameterValues(condition);
            var dataSet = DBHelper.ExecuteDataSet(cmd);
            var pagedList = new PagedList<MetaModel<Guid>>(condition, dataSet);
            return pagedList;
        }

        public int Create售后操作(MetaModel<Guid> meta)
        {
            var cmd = ProcCommands.sp_Create售后操作().SetParameterValues(meta);
            var rowCount = (int)DBHelper.ExecuteScalar(cmd);
            return rowCount;
        }

        public int Update售后操作(MetaModel<Guid> meta)
        {
            var cmd = ProcCommands.sp_Update售后操作().SetParameterValues(meta);
            var rowCount = (int)DBHelper.ExecuteScalar(cmd);
            return rowCount;
        }

        public int Delete售后操作(Guid id)
        {
            var cmd = ProcCommands.sp_Delete售后操作().SetParameterValues(new
            {
                ID = id
            });
            var rowCount = (int)DBHelper.ExecuteScalar(cmd);
            return rowCount;
        }

        public MetaModel<Guid> Get售后操作By(Guid id)
        {
            var cmd = ProcCommands.sp_Get售后操作ByID().SetParameterValues(new
            {
                ID = id
            });

            return DBHelper.ExecuteEntityList<MetaModel<Guid>>(cmd).FirstOrDefault();
        }


        public PagedList<MetaModel<Guid>> Get售后原因List(MetaCondition condition)
        {
            var cmd = ProcCommands.sp_售后原因List().SetParameterValues(condition);
            var dataSet = DBHelper.ExecuteDataSet(cmd);
            var pagedList = new PagedList<MetaModel<Guid>>(condition, dataSet);
            return pagedList;
        }

        public int Create售后原因(MetaModel<Guid> meta)
        {
            var cmd = ProcCommands.sp_Create售后原因().SetParameterValues(meta);
            var rowCount = (int)DBHelper.ExecuteScalar(cmd);
            return rowCount;
        }

        public int Update售后原因(MetaModel<Guid> meta)
        {
            var cmd = ProcCommands.sp_Update售后原因().SetParameterValues(meta);
            var rowCount = (int)DBHelper.ExecuteScalar(cmd);
            return rowCount;
        }

        public int Delete售后原因(Guid id)
        {
            var cmd = ProcCommands.sp_Delete售后原因().SetParameterValues(new
            {
                ID = id
            });
            var rowCount = (int)DBHelper.ExecuteScalar(cmd);
            return rowCount;
        }

        public MetaModel<Guid> Get售后原因By(Guid id)
        {
            var cmd = ProcCommands.sp_Get售后原因ByID().SetParameterValues(new
            {
                ID = id
            });

            return DBHelper.ExecuteEntityList<MetaModel<Guid>>(cmd).FirstOrDefault();
        }
    }
}
