using DaSongERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YK;

namespace DaSongERP.Dal
{
    public class UserDao : Dao
    {
        public UserModel GetUserBy(string userName)
        {
            var cmd = ProcCommands.sp_GetUserByUserName().SetParameterValues(new
            {
                UserName = userName
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
    }
}
