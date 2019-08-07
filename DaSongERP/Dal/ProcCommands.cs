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
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ID", Value = DBNull.Value });
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

        #region sp_CreateOrder
        public static SqlCommand sp_CreateOrder()
        {
            var cmd = new SqlCommand("sp_CreateOrder") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ID", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@进货日期", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@货号", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@商品图片", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@进货数量", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@店铺", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@JD订单号", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@客人姓名", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@客人电话", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@客人地址", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@淘宝账号", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@淘宝订单号", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@采购备注", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@京东价", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@成本价", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@采购人ID", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@高亮", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@现货", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@中转仓", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_CreateOrder

        #region sp_CreateOrder4Excel
        public static SqlCommand sp_CreateOrder4Excel()
        {
            var cmd = new SqlCommand("sp_CreateOrder4Excel") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@进货日期", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@货号", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@进货数量", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@店铺", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@JD订单号", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@淘宝订单号", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@采购备注", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@来快递", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@来快递单号", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@转发单号", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@淘宝账号", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@京东价", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@成本价", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@采购人ID", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@现货", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@中转仓", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_CreateOrder4Excel

        #region sp_GetOrderBy订单号
        public static SqlCommand sp_GetOrderBy订单号()
        {
            var cmd = new SqlCommand("sp_GetOrderBy订单号") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@JD订单号", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@淘宝订单号", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@货号", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@采购备注", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ID", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_GetOrderBy订单号

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
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@店铺", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@JD订单号", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@客人姓名", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@客人电话", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@客人地址", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@淘宝账号", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@淘宝订单号", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@采购备注", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@京东价", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@成本价", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@订单修改备注", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@采购人ID", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@高亮", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@订单终结", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@订单终结备注", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@现货", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@中转仓", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_UpdateOrder

        #region sp_订单跟进
        public static SqlCommand sp_订单跟进()
        {
            var cmd = new SqlCommand("sp_订单跟进") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ID", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@来快递", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@来快递单号", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@发货时间", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@发货备注", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@跟进人ID", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@高亮", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@订单终结", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@订单终结备注", Value = DBNull.Value });
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
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@客人姓名", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@客人电话", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@客人地址", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_Update电话备注

        #region sp_Update电话客服
        public static SqlCommand sp_Update电话客服()
        {
            var cmd = new SqlCommand("sp_Update电话客服") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ID", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@电话客服ID", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@电话备注", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@高亮", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@客人姓名", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@客人电话", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@客人地址", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@订单修改备注", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_Update电话客服

        #region sp_Update拆包
        public static SqlCommand sp_Update拆包()
        {
            var cmd = new SqlCommand("sp_Update拆包") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ID", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@审单操作ID", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@拆包人员备注", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@转发单号", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@拆包人ID", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@订单终结", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@订单终结备注", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@高亮", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_Update拆包

        #region sp_Update售后
        public static SqlCommand sp_Update售后()
        {
            var cmd = new SqlCommand("sp_Update售后") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ID", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@售后操作ID", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@售后原因ID", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@售后备注", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@售后人员ID", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@客人退回单号", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@客人姓名", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@客人电话", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@客人地址", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@退款金额", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@高亮", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@售后完结", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@订单修改备注", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@淘宝退回单号", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_Update售后

        #region sp_Update客服
        public static SqlCommand sp_Update客服()
        {
            var cmd = new SqlCommand("sp_Update客服") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ID", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@客人姓名", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@客人电话", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@客人地址", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@订单修改备注", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@客服ID", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@高亮", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_Update客服

        //#region sp_GetAllUsers
        //public static SqlCommand sp_GetAllUsers()
        //{
        //    var cmd = new SqlCommand("sp_GetAllUsers") { CommandType = CommandType.StoredProcedure };
        //    cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Search", Value = DBNull.Value });
        //    return cmd;
        //}
        //#endregion sp_GetAllUsers

        #region sp_CreateUser
        public static SqlCommand sp_CreateUser()
        {
            var cmd = new SqlCommand("sp_CreateUser") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ID", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@UserName", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Password", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Name", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@PermissionID", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_CreateUser

        #region sp_UpdateUser
        public static SqlCommand sp_UpdateUser()
        {
            var cmd = new SqlCommand("sp_UpdateUser") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ID", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@UserName", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Password", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Name", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@PermissionID", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_UpdateUser

        #region sp_GetAllPermissions
        public static SqlCommand sp_GetAllPermissions()
        {
            var cmd = new SqlCommand("sp_GetAllPermissions") { CommandType = CommandType.StoredProcedure };
            return cmd;
        }
        #endregion sp_GetAllPermissions

        #region sp_RemoveUser
        public static SqlCommand sp_RemoveUser()
        {
            var cmd = new SqlCommand("sp_RemoveUser") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ID", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_RemoveUser

        #region sp_GetOrders
        public static SqlCommand sp_GetOrders()
        {
            var cmd = new SqlCommand("sp_GetOrders") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@JD订单号", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@来快递单号", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@售后人员ID", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@售后完结", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@客服ID", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@已跟进", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@已导入", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@已拆包", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_GetOrders

        #region sp_Get未导入Orders
        public static SqlCommand sp_Get未导入Orders()
        {
            var cmd = new SqlCommand("sp_Get未导入Orders") { CommandType = CommandType.StoredProcedure };
            return cmd;
        }
        #endregion sp_Get未导入Orders

        #region sp_跟进List
        public static SqlCommand sp_跟进List()
        {
            var cmd = new SqlCommand("sp_跟进List") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@PageIndex", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@PageSize", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@OrderBy", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@OrderByDesc", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@跟进人ID", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@JD订单号", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@拆包超时", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@已跟进", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@已拆包", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@货号", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@自采", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@高亮", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@中转仓", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_跟进List

        #region sp_GetAll快递
        public static SqlCommand sp_GetAll快递()
        {
            var cmd = new SqlCommand("sp_GetAll快递") { CommandType = CommandType.StoredProcedure };
            return cmd;
        }
        #endregion sp_GetAll快递

        #region sp_电话客服List
        public static SqlCommand sp_电话客服List()
        {
            var cmd = new SqlCommand("sp_电话客服List") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@PageIndex", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@PageSize", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@OrderBy", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@OrderByDesc", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@电话客服ID", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@JD订单号", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@客人地址", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@已导入", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@高亮", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_电话客服List

        #region sp_采购List
        public static SqlCommand sp_采购List()
        {
            var cmd = new SqlCommand("sp_采购List") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@PageIndex", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@PageSize", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@OrderBy", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@OrderByDesc", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@采购人ID", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@JD订单号", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@货号", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@自采", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@高亮", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@现货", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@中转仓", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_采购List

        #region sp_拆包审单List
        public static SqlCommand sp_拆包审单List()
        {
            var cmd = new SqlCommand("sp_拆包审单List") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@PageIndex", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@PageSize", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@OrderBy", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@OrderByDesc", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@拆包人ID", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@JD订单号", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@来快递单号", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@已拆包", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@拆包超时", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@货号", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@自采", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@高亮", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_拆包审单List

        #region sp_售后List
        public static SqlCommand sp_售后List()
        {
            var cmd = new SqlCommand("sp_售后List") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@PageIndex", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@PageSize", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@OrderBy", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@OrderByDesc", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@售后人员ID", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@JD订单号", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@已售后", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@售后完结", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@高亮", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@现货", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_售后List

        #region sp_客服List
        public static SqlCommand sp_客服List()
        {
            var cmd = new SqlCommand("sp_客服List") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@PageIndex", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@PageSize", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@OrderBy", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@OrderByDesc", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@JD订单号", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@货号", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@自采", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@高亮", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_客服List

        #region sp_审单操作List
        public static SqlCommand sp_审单操作List()
        {
            var cmd = new SqlCommand("sp_审单操作List") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@PageIndex", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@PageSize", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@OrderBy", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@OrderByDesc", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_审单操作List

        #region sp_Create审单操作
        public static SqlCommand sp_Create审单操作()
        {
            var cmd = new SqlCommand("sp_Create审单操作") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ID", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Name", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@SN", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_Create审单操作

        #region sp_Update审单操作
        public static SqlCommand sp_Update审单操作()
        {
            var cmd = new SqlCommand("sp_Update审单操作") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ID", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Name", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@SN", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_Update审单操作

        #region sp_Delete审单操作
        public static SqlCommand sp_Delete审单操作()
        {
            var cmd = new SqlCommand("sp_Delete审单操作") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ID", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_Delete审单操作

        #region sp_Get审单操作ByID
        public static SqlCommand sp_Get审单操作ByID()
        {
            var cmd = new SqlCommand("sp_Get审单操作ByID") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ID", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_Get审单操作ByID

        #region sp_售后操作List
        public static SqlCommand sp_售后操作List()
        {
            var cmd = new SqlCommand("sp_售后操作List") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@PageIndex", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@PageSize", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@OrderBy", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@OrderByDesc", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_售后操作List

        #region sp_Create售后操作
        public static SqlCommand sp_Create售后操作()
        {
            var cmd = new SqlCommand("sp_Create售后操作") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ID", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Name", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@SN", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_Create售后操作

        #region sp_Update售后操作
        public static SqlCommand sp_Update售后操作()
        {
            var cmd = new SqlCommand("sp_Update售后操作") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ID", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Name", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@SN", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_Update售后操作

        #region sp_Delete售后操作
        public static SqlCommand sp_Delete售后操作()
        {
            var cmd = new SqlCommand("sp_Delete售后操作") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ID", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_Delete售后操作

        #region sp_Get售后操作ByID
        public static SqlCommand sp_Get售后操作ByID()
        {
            var cmd = new SqlCommand("sp_Get售后操作ByID") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ID", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_Get售后操作ByID


        #region sp_售后原因List
        public static SqlCommand sp_售后原因List()
        {
            var cmd = new SqlCommand("sp_售后原因List") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@PageIndex", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@PageSize", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@OrderBy", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@OrderByDesc", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_售后原因List

        #region sp_Create售后原因
        public static SqlCommand sp_Create售后原因()
        {
            var cmd = new SqlCommand("sp_Create售后原因") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ID", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Name", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@SN", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_Create售后原因

        #region sp_Update售后原因
        public static SqlCommand sp_Update售后原因()
        {
            var cmd = new SqlCommand("sp_Update售后原因") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ID", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Name", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@SN", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_Update售后原因

        #region sp_Delete售后原因
        public static SqlCommand sp_Delete售后原因()
        {
            var cmd = new SqlCommand("sp_Delete售后原因") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ID", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_Delete售后原因

        #region sp_Get售后原因ByID
        public static SqlCommand sp_Get售后原因ByID()
        {
            var cmd = new SqlCommand("sp_Get售后原因ByID") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ID", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_Get售后原因ByID


        #region sp_中转仓List
        public static SqlCommand sp_中转仓List()
        {
            var cmd = new SqlCommand("sp_中转仓List") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@PageIndex", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@PageSize", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@OrderBy", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@OrderByDesc", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_中转仓List

        #region sp_Create中转仓
        public static SqlCommand sp_Create中转仓()
        {
            var cmd = new SqlCommand("sp_Create中转仓") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ID", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Name", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@SN", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_Create中转仓

        #region sp_Update中转仓
        public static SqlCommand sp_Update中转仓()
        {
            var cmd = new SqlCommand("sp_Update中转仓") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ID", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Name", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@SN", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_Update中转仓

        #region sp_Delete中转仓
        public static SqlCommand sp_Delete中转仓()
        {
            var cmd = new SqlCommand("sp_Delete中转仓") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ID", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_Delete中转仓

        #region sp_Get中转仓ByID
        public static SqlCommand sp_Get中转仓ByID()
        {
            var cmd = new SqlCommand("sp_Get中转仓ByID") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ID", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_Get中转仓ByID

        #region sp_UserList
        public static SqlCommand sp_UserList()
        {
            var cmd = new SqlCommand("sp_UserList") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@PageIndex", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@PageSize", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@OrderBy", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@OrderByDesc", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_UserList

        #region sp_Get待处理订单数量
        public static SqlCommand sp_Get待处理订单数量()
        {
            var cmd = new SqlCommand("sp_Get待处理订单数量") { CommandType = CommandType.StoredProcedure };
            return cmd;
        }
        #endregion sp_Get待处理订单数量

        #region sp_Update店铺
        public static SqlCommand sp_Update店铺()
        {
            var cmd = new SqlCommand("sp_Update店铺") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ID", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Name", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Prefix", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_Update店铺

        #region sp_Get店铺
        public static SqlCommand sp_Get店铺()
        {
            var cmd = new SqlCommand("sp_Get店铺") { CommandType = CommandType.StoredProcedure };
            return cmd;
        }
        #endregion sp_Get店铺

        #region sp_Get店铺ByID
        public static SqlCommand sp_Get店铺ByID()
        {
            var cmd = new SqlCommand("sp_Get店铺ByID") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ID", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_Get店铺ByID

        #region sp_Delete店铺
        public static SqlCommand sp_Delete店铺()
        {
            var cmd = new SqlCommand("sp_Delete店铺") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ID", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_Delete店铺

        #region sp_Create店铺
        public static SqlCommand sp_Create店铺()
        {
            var cmd = new SqlCommand("sp_Create店铺") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@ID", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Name", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@Prefix", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_Create店铺

        #region sp_店铺List
        public static SqlCommand sp_店铺List()
        {
            var cmd = new SqlCommand("sp_店铺List") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@PageIndex", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@PageSize", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@OrderBy", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@OrderByDesc", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_店铺List

        #region sp_Update拆包4Excel
        public static SqlCommand sp_Update拆包4Excel()
        {
            var cmd = new SqlCommand("sp_Update拆包4Excel") { CommandType = CommandType.StoredProcedure };
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@JD订单号", Value = DBNull.Value });
            cmd.Parameters.Add(new SqlParameter() { ParameterName = "@来快递单号", Value = DBNull.Value });
            return cmd;
        }
        #endregion sp_Update拆包4Excel

        #region sp_GetAll中转仓
        public static SqlCommand sp_GetAll中转仓()
        {
            var cmd = new SqlCommand("sp_GetAll中转仓") { CommandType = CommandType.StoredProcedure };
            return cmd;
        }
        #endregion sp_GetAll中转仓
    }
}
