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
    public class 库存商品Dao : Dao
    {
        public 库存商品PagedList Get库存商品List(库存商品Condition condition)
        {
            var cmd = ProcCommands.sp_库存商品List().SetParameterValues(condition);
            var dataSet = DBHelper.ExecuteDataSet(cmd);
            var pagedList = new 库存商品PagedList(condition, dataSet);
            pagedList.现货数量 = (int)dataSet.Tables[2].Rows[0]["现货数量"];
            pagedList.在途数量 = (int)dataSet.Tables[2].Rows[0]["在途数量"];
            return pagedList;
        }

        public int Create库存商品(库存商品Model model)
        {
            var cmd = ProcCommands.sp_Create库存商品().SetParameterValues(model);
            var rowCount = (int)DBHelper.ExecuteScalar(cmd);
            return rowCount;
        }

        public int Update库存商品(库存商品Model model)
        {
            var cmd = ProcCommands.sp_Update库存商品().SetParameterValues(model);
            var rowCount = (int)DBHelper.ExecuteScalar(cmd);
            return rowCount;
        }

        public int Delete库存商品(Guid id)
        {
            var cmd = ProcCommands.sp_Delete库存商品().SetParameterValues(new
            {
                ID = id
            });
            var rowCount = (int)DBHelper.ExecuteScalar(cmd);
            return rowCount;
        }

        public 库存商品Model Get库存商品By(Guid id)
        {
            var cmd = ProcCommands.sp_Get库存商品ByID().SetParameterValues(new
            {
                ID = id
            });

            return DBHelper.ExecuteEntityList<库存商品Model>(cmd).FirstOrDefault();
        }

        public IList<库存商品Model> Get库存商品By(库存商品Condition condition)
        {
            var cmd = ProcCommands.sp_Get规格By货号().SetParameterValues(condition);
            return DBHelper.ExecuteEntityList<库存商品Model>(cmd);
        }

        public int Save库存动量(库存动量Model model)
        {
            var cmd = ProcCommands.sp_Save库存动量().SetParameterValues(model);
            return (int)DBHelper.ExecuteScalar(cmd);
        }

        public int Delete库存动量(Guid orderID)
        {
            var cmd = ProcCommands.sp_Delete库存动量().SetParameterValues(new
            {
                OrderID = orderID
            });
            return (int)DBHelper.ExecuteScalar(cmd);
        }

        public PagedList<库存动量Model> Get库存动量List(库存动量Condition condition)
        {
            var cmd = ProcCommands.sp_库存动量List().SetParameterValues(condition);
            var dataSet = DBHelper.ExecuteDataSet(cmd);
            var pagedList = new PagedList<库存动量Model>(condition, dataSet);
            return pagedList;
        }
    }
}
