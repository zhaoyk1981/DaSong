using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YK.Model;
using YK.Utils;

namespace YK
{
    public static class SystemDataSqlClientExtendMethods
    {
        public static SqlCommand SetParameterValues(this SqlCommand cmd, object entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            var entityType = entity.GetType();
            foreach (SqlParameter pm in cmd.Parameters)
            {
                var name = pm.ParameterName.TrimStart('@');
                var prop = entityType.GetPropertyInfo(name);
                if (prop == null)
                {
                    continue;
                }

                var value = prop.GetValue(entity);
                if (value != null)
                {
                    if (prop.PropertyType.Name == "List`1" || prop.PropertyType.Name == "IList`1")
                    {
                        value = value.TryChangeType(typeof(DataTable));
                    }
                    else if (prop.PropertyType.Name == "Dictionary`2" || prop.PropertyType.Name == "IDictionary`2")
                    {
                        value = value.TryChangeType(typeof(DataTable));
                    }
                    else
                    {
                        value = value.TryChangeType(prop.PropertyType);
                    }
                }

                pm.Value = value ?? DBNull.Value;
            }

            var pagingCondition = entity as PagingCondition;
            if (pagingCondition != null)
            {
                for (var i = 0; i < pagingCondition.ThenByList.Count; i++)
                {
                    cmd.Parameters[$"@ThenBy{(i + 1)}"].Value = pagingCondition.ThenByList[i].ColumnName;
                    cmd.Parameters[$"@ThenByDesc{(i + 1)}"].Value = pagingCondition.ThenByList[i].IsDesc;
                }
            }

            return cmd;
        }

        public static DataTable ExecDataTable(this SqlCommand cmd, string connectionName = null)
        {
            var dbHelper = new DBHelper(connectionName);
            return dbHelper.ExecuteDataTable(cmd);
        }

        public static DataSet ExecDataSet(this SqlCommand cmd, string connectionName = null)
        {
            var dbHelper = new DBHelper(connectionName);
            return dbHelper.ExecuteDataSet(cmd);
        }

        public static object ExecScalar(this SqlCommand cmd, string connectionName = null)
        {
            var dbHelper = new DBHelper(connectionName);
            return dbHelper.ExecuteScalar(cmd);
        }

        public static int ExecNonQuery(this SqlCommand cmd, string connectionName = null)
        {
            var dbHelper = new DBHelper(connectionName);
            return dbHelper.ExecuteNonQuery(cmd);
        }
    }
}
