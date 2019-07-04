using DaSongERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YK;
namespace DaSongERP.Dal
{
    public class OrderDao : Dao
    {
        public int Create(OrderModel order)
        {
            var cmd = ProcCommands.sp_CreateOrder().SetParameterValues(order);
            var rowCount = (int)DBHelper.ExecuteScalar(cmd);
            return rowCount;
        }

        public OrderModel GetOrderBy(string jd订单号, Guid? id = null)
        {
            var cmd = ProcCommands.sp_GetOrderByJD订单号().SetParameterValues(new
            {
                JD订单号 = jd订单号,
                ID = id
            });
            var list = DBHelper.ExecuteEntityList<OrderModel>(cmd);
            return list.FirstOrDefault();
        }

        public OrderModel GetOrderBy(Guid id)
        {
            var cmd = ProcCommands.sp_GetOrderByID().SetParameterValues(new
            {
                ID = id
            });
            var list = DBHelper.ExecuteEntityList<OrderModel>(cmd);
            return list.FirstOrDefault();
        }

        public int Update(OrderModel order)
        {
            var cmd = ProcCommands.sp_UpdateOrder().SetParameterValues(order);
            var rowCount = (int)DBHelper.ExecuteScalar(cmd);
            return rowCount;
        }

        public int 订单跟进(OrderModel order)
        {
            var cmd = ProcCommands.sp_订单跟进().SetParameterValues(order);
            var rowCount = (int)DBHelper.ExecuteScalar(cmd);
            return rowCount;
        }
    }
}
