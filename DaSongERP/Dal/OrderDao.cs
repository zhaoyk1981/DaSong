using DaSongERP.Conditions;
using DaSongERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YK;
using YK.Model;

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

        public int Create4Excel(OrderModel order)
        {
            var cmd = ProcCommands.sp_CreateOrder4Excel().SetParameterValues(order);
            var rowCount = (int)DBHelper.ExecuteScalar(cmd);
            return rowCount;
        }

        public OrderModel GetOrderBy订单号(OrderModel order)
        {
            var cmd = ProcCommands.sp_GetOrderBy订单号().SetParameterValues(order);
            var list = DBHelper.ExecuteEntityList<OrderModel>(cmd);
            return list.FirstOrDefault();
        }

        public IList<OrderModel> GetOrdersBy(string jd订单号, string 来快递单号)
        {
            var cmd = ProcCommands.sp_GetOrders().SetParameterValues(new
            {
                JD订单号 = jd订单号,
                来快递单号 = 来快递单号
            });
            var list = DBHelper.ExecuteEntityList<OrderModel>(cmd);
            return list;
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

        //public IList<OrderModel> GetOrdersBy(OrderModel condition)
        //{
        //    var cmd = ProcCommands.sp_GetOrders().SetParameterValues(condition);
        //    var list = DBHelper.ExecuteEntityList<OrderModel>(cmd);
        //    return list;
        //}

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

        public int Update电话备注(OrderModel order)
        {
            var cmd = ProcCommands.sp_Update电话备注().SetParameterValues(order);
            var 导入结果 = (int)DBHelper.ExecuteScalar(cmd);
            return 导入结果;
        }

        public int Update电话客服(OrderModel order)
        {
            var cmd = ProcCommands.sp_Update电话客服().SetParameterValues(order);
            var rowCount = (int)DBHelper.ExecuteScalar(cmd);
            return rowCount;
        }

        public IList<OrderModel> Get未导入Orders()
        {
            var cmd = ProcCommands.sp_Get未导入Orders();
            var list = DBHelper.ExecuteEntityList<OrderModel>(cmd);
            return list;
        }

        public int Update拆包(OrderModel order)
        {
            var cmd = ProcCommands.sp_Update拆包().SetParameterValues(order);
            var result = (int)DBHelper.ExecuteScalar(cmd);
            return result;
        }

        public int Update售后(OrderModel order)
        {
            var cmd = ProcCommands.sp_Update售后().SetParameterValues(order);
            var result = (int)DBHelper.ExecuteScalar(cmd);
            return result;
        }

        public int Update客服(OrderModel order)
        {
            var cmd = ProcCommands.sp_Update客服().SetParameterValues(order);
            var result = (int)DBHelper.ExecuteScalar(cmd);
            return result;
        }


        public PagedList<OrderModel> Get跟进List(OrderCondition condition)
        {
            var cmd = ProcCommands.sp_跟进List().SetParameterValues(condition);
            var dataSet = DBHelper.ExecuteDataSet(cmd);
            var pagedList = new PagedList<OrderModel>(condition, dataSet);
            this.SetRowIndex(pagedList);
            return pagedList;
        }

        private void SetRowIndex(PagedList<OrderModel> list)
        {
            for (var i = 0; i < list.DataSource.Count; i++)
            {
                list.DataSource[i].RowIndex = list.PageIndex * list.PageSize + i;
            }
        }

        public PagedList<OrderModel> Get电话客服List(OrderCondition condition)
        {
            var cmd = ProcCommands.sp_电话客服List().SetParameterValues(condition);
            var dataSet = DBHelper.ExecuteDataSet(cmd);
            var pagedList = new PagedList<OrderModel>(condition, dataSet);
            this.SetRowIndex(pagedList);
            return pagedList;
        }

        public PagedList<OrderModel> Get采购List(OrderCondition condition)
        {
            var cmd = ProcCommands.sp_采购List().SetParameterValues(condition);
            var dataSet = DBHelper.ExecuteDataSet(cmd);
            var pagedList = new PagedList<OrderModel>(condition, dataSet);
            this.SetRowIndex(pagedList);
            return pagedList;
        }

        public PagedList<OrderModel> Get拆包审单List(OrderCondition condition)
        {
            var cmd = ProcCommands.sp_拆包审单List().SetParameterValues(condition);
            var dataSet = DBHelper.ExecuteDataSet(cmd);
            var pagedList = new PagedList<OrderModel>(condition, dataSet);
            this.SetRowIndex(pagedList);
            return pagedList;
        }

        public PagedList<OrderModel> Get售后List(OrderCondition condition)
        {
            var cmd = ProcCommands.sp_售后List().SetParameterValues(condition);
            var dataSet = DBHelper.ExecuteDataSet(cmd);
            var pagedList = new PagedList<OrderModel>(condition, dataSet);
            this.SetRowIndex(pagedList);
            return pagedList;
        }

        public PagedList<OrderModel> Get客服List(OrderCondition condition)
        {
            var cmd = ProcCommands.sp_客服List().SetParameterValues(condition);
            var dataSet = DBHelper.ExecuteDataSet(cmd);
            var pagedList = new PagedList<OrderModel>(condition, dataSet);
            this.SetRowIndex(pagedList);
            return pagedList;
        }

        public OrderCountModel Get待处理订单数量()
        {
            var cmd = ProcCommands.sp_Get待处理订单数量();
            var m = DBHelper.ExecuteEntityList<OrderCountModel>(cmd).FirstOrDefault();
            return m;
        }

        public int Update拆包4Excel(OrderModel order)
        {
            var cmd = ProcCommands.sp_Update拆包4Excel().SetParameterValues(order);
            var rowCount = (int)DBHelper.ExecuteScalar(cmd);
            return rowCount;
        }

        public int UpdateOrder在途待发(Guid orderID, bool 在途待发)
        {
            var cmd = ProcCommands.sp_UpdateOrder在途待发().SetParameterValues(new
            {
                ID = orderID,
                在途待发 = 在途待发
            });
            var rowCount = (int)DBHelper.ExecuteScalar(cmd);
            return rowCount;
        }

        public void DeleteOrder(Guid orderID)
        {
            var cmd = ProcCommands.sp_DeleteOrder().SetParameterValues(new
            {
                ID = orderID
            });
            DBHelper.ExecuteNonQuery(cmd);
        }

        public int UpdateOrder高亮(Guid orderID, bool 高亮)
        {
            var cmd = ProcCommands.sp_UpdateOrder高亮().SetParameterValues(
                new
                {
                    ID = orderID,
                    高亮 = 高亮
                });
            var rowCount = (int)DBHelper.ExecuteScalar(cmd);
            return rowCount;
        }
    }
}
