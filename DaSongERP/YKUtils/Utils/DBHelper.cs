using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YK.Mappers;

namespace YK.Utils
{
    public class DBHelper
    {
        public DBHelper(string connectionName = null)
        {
            connectionName = connectionName ?? ConfigurationManager.ConnectionStrings[0]?.Name;
            this.ConnectionName = connectionName;
        }

        protected string ConnectionName { get; set; }

        public string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings[this.ConnectionName].ConnectionString;
        }

        public SqlConnection CreateConnection()
        {
            return new SqlConnection(this.GetConnectionString());
        }

        public SqlCommand CreateCommand(string cmdTxt, CommandType cmdType = CommandType.StoredProcedure)
        {
            var cmd = new SqlCommand(cmdTxt, CreateConnection());

            cmd.CommandType = cmdType;
            return cmd;
        }

        public SqlCommand CreateCommand(string cmdTxt, IDictionary<string, object> parameters, CommandType cmdType = CommandType.StoredProcedure)
        {
            var cmd = this.CreateCommand(cmdTxt, cmdType);
            foreach (KeyValuePair<string, object> p in parameters)
            {
                cmd.Parameters.AddWithValue(p.Key, p.Value ?? DBNull.Value);
            }

            return cmd;
        }

        public DataSet ExecuteDataSet(string cmdTxt, IDictionary<string, object> parameters, CommandType cmdType = CommandType.StoredProcedure)
        {
            var cmd = this.CreateCommand(cmdTxt, parameters, cmdType);
            return ExecuteDataSet(cmd);
        }

        public DataSet ExecuteDataSet(SqlCommand cmd)
        {
            cmd.Connection = cmd.Connection ?? this.CreateConnection();
            var result = new DataSet();
            var adapter = new SqlDataAdapter(cmd);
            adapter.Fill(result);
            return result;
        }

        public DataTable ExecuteDataTable(string cmdTxt, IDictionary<string, object> parameters, CommandType cmdType = CommandType.StoredProcedure)
        {
            var cmd = this.CreateCommand(cmdTxt, parameters, cmdType);
            return ExecuteDataTable(cmd);
        }

        public DataTable ExecuteDataTable(SqlCommand cmd)
        {
            cmd.Connection = cmd.Connection ?? this.CreateConnection();
            var result = new DataTable();
            var adapter = new SqlDataAdapter(cmd);
            adapter.Fill(result);
            return result;
        }

        public IList<T> ExecuteEntityList<T>(SqlCommand cmd)
            where T : new()
        {
            var dt = this.ExecuteDataTable(cmd);
            var list = DbMapperUtil.Map<T>(dt);
            return list;
        }

        public object ExecuteScalar(string cmdTxt, IDictionary<string, object> parameters, CommandType cmdType = CommandType.StoredProcedure)
        {
            var cmd = this.CreateCommand(cmdTxt, parameters, cmdType);
            return ExecuteScalar(cmd);
        }

        public object ExecuteScalar(SqlCommand cmd)
        {
            cmd.Connection = cmd.Connection ?? this.CreateConnection();
            object result = null;
            try
            {
                cmd.Connection.Open();
                result = cmd.ExecuteScalar();
                cmd.Connection.Close();
            }
            catch
            {
                try
                {
                    cmd.Connection.Close();
                }
                catch
                {

                }

                throw;
            }

            return result;
        }

        public int ExecuteNonQuery(string cmdTxt, IDictionary<string, object> parameters, CommandType cmdType = CommandType.StoredProcedure)
        {
            var cmd = this.CreateCommand(cmdTxt, parameters, cmdType);
            return ExecuteNonQuery(cmd);
        }

        public int ExecuteNonQuery(SqlCommand cmd)
        {
            cmd.Connection = cmd.Connection ?? this.CreateConnection();
            int result = 0;
            try
            {
                cmd.Connection.Open();
                result = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch
            {
                try
                {
                    cmd.Connection.Close();
                }
                catch
                {

                }

                throw;
            }

            return result;
        }
    }
}
