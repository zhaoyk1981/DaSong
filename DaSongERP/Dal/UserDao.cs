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
    public class UserDao : Dao
    {
        public UserModel GetUserBy(string userName, Guid? id = null)
        {
            var cmd = ProcCommands.sp_GetUserByUserName().SetParameterValues(new
            {
                UserName = userName,
                ID = id
            });

            var list = this.DBHelper.ExecuteEntityList<UserModel>(cmd);
            return list.FirstOrDefault();
        }

        public UserModel GetUserBy(Guid id)
        {
            var cmd = ProcCommands.sp_GetUserByID().SetParameterValues(new
            {
                ID = id
            });

            var list = this.DBHelper.ExecuteEntityList<UserModel>(cmd);
            return list.FirstOrDefault();
        }

        //public IList<UserModel> GetUserList(string search = null)
        //{
        //    var cmd = ProcCommands.sp_GetAllUsers().SetParameterValues(new
        //    {
        //        Search = search
        //    });
        //    var list = this.DBHelper.ExecuteEntityList<UserModel>(cmd);
        //    return list;
        //}

        public int RemoveUser(Guid id)
        {
            var cmd = ProcCommands.sp_RemoveUser().SetParameterValues(new
            {
                ID = id
            });

            var rowCount = (int)DBHelper.ExecuteScalar(cmd);
            return rowCount;
        }

        public IList<PermissionModel> GetAllPermissions()
        {
            var cmd = ProcCommands.sp_GetAllPermissions();
            var list = DBHelper.ExecuteEntityList<PermissionModel>(cmd);
            return list;
        }

        public int Create(UserModel user)
        {
            var cmd = ProcCommands.sp_CreateUser().SetParameterValues(user);
            var rowCount = (int)DBHelper.ExecuteScalar(cmd);
            return rowCount;
        }

        public int Update(UserModel user)
        {
            var cmd = ProcCommands.sp_UpdateUser().SetParameterValues(user);
            var rowCount = (int)DBHelper.ExecuteScalar(cmd);
            return rowCount;
        }

        public PagedList<UserModel> GetUserList(UserCondition condition)
        {
            var cmd = ProcCommands.sp_UserList().SetParameterValues(condition);
            var dataSet = DBHelper.ExecuteDataSet(cmd);
            var pagedList = new PagedList<UserModel>(condition, dataSet);
            return pagedList;
        }
    }
}
