using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaSongERP.Dal
{
    public class ProcCommands
    {
        #region sp_GetUserByUserName
        public static SqlCommand sp_GetUserByUserName()
        {
            var cmd = new SqlCommand("sp_GetUserByUserName") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@UserName", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_GetUserByUserName

        #region sp_GetUserByID
        public static SqlCommand sp_GetUserByID()
        {
            var cmd = new SqlCommand("sp_GetUserByID") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ID", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_GetUserByID

        #region sp_Get店铺
        public static SqlCommand sp_Get店铺()
        {
            var cmd = new SqlCommand("sp_Get店铺") { CommandType = CommandType.StoredProcedure };
            return cmd;
        }
        #endregion sp_Get店铺

        #region sp_Get审单操作
        public static SqlCommand sp_Get审单操作()
        {
            var cmd = new SqlCommand("sp_Get审单操作") { CommandType = CommandType.StoredProcedure };
            return cmd;
        }
        #endregion sp_Get审单操作

        #region sp_Get售后操作
        public static SqlCommand sp_Get售后操作()
        {
            var cmd = new SqlCommand("sp_Get售后操作") { CommandType = CommandType.StoredProcedure };
            return cmd;
        }
        #endregion sp_Get售后操作

        #region sp_Get售后原因
        public static SqlCommand sp_Get售后原因()
        {
            var cmd = new SqlCommand("sp_Get售后原因") { CommandType = CommandType.StoredProcedure };
            return cmd;
        }
        #endregion sp_Get售后原因

        #region sp_Get淘宝账号
        public static SqlCommand sp_Get淘宝账号()
        {
            var cmd = new SqlCommand("sp_Get淘宝账号") { CommandType = CommandType.StoredProcedure };
            return cmd;
        }
        #endregion sp_Get淘宝账号

        #region sp_Get库存
        public static SqlCommand sp_Get库存()
        {
            var cmd = new SqlCommand("sp_Get库存") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@货号", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_Get库存

        #region sp_CreateOrder
        public static SqlCommand sp_CreateOrder()
        {
            var cmd = new SqlCommand("sp_CreateOrder") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ID", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@进货日期", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@货号", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@商品图片", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@进货数量", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@店铺ID", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@JD订单号", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@客人地址", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@淘宝账号ID", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@淘宝订单号", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@采购备注", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@订单修改备注", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@京东价", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@成本价", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@采购人ID", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_CreateOrder

        #region sp_GetOrderByJD订单号
        public static SqlCommand sp_GetOrderByJD订单号()
        {
            var cmd = new SqlCommand("sp_GetOrderByJD订单号") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@JD订单号", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ID", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_GetOrderByJD订单号

        #region sp_GetOrderByID
        public static SqlCommand sp_GetOrderByID()
        {
            var cmd = new SqlCommand("sp_GetOrderByID") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ID", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_GetOrderByID

        #region sp_UpdateOrder
        public static SqlCommand sp_UpdateOrder()
        {
            var cmd = new SqlCommand("sp_UpdateOrder") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ID", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@货号", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@商品图片", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@进货数量", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@店铺ID", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@JD订单号", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@客人地址", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@淘宝账号ID", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@淘宝订单号", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@采购备注", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@订单修改备注", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@京东价", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@成本价", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@采购人ID", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_UpdateOrder

        #region sp_订单跟进
        public static SqlCommand sp_订单跟进()
        {
            var cmd = new SqlCommand("sp_订单跟进") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ID", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@来快递单号", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@发货时间", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@发货备注", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@跟进人ID", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_订单跟进

        #region sp_Update电话备注
        public static SqlCommand sp_Update电话备注()
        {
            var cmd = new SqlCommand("sp_Update电话备注") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@JD订单号", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@电话客服ID", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@电话备注", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_Update电话备注

        #region sp_Count未导入
        public static SqlCommand sp_Count未导入()
        {
            var cmd = new SqlCommand("sp_Count未导入") { CommandType = CommandType.StoredProcedure };
            return cmd;
        }
        #endregion sp_Count未导入
    }
}
