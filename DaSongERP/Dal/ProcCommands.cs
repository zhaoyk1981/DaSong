using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
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
    }
}
