using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YK.Mappers;

namespace YK
{
    public static class SystemDataExtendMethods
    {
        public static string GetString(this DataRow row, string columnName, string defaultValue = null)
        {
            return row.IsNull(columnName) ? defaultValue : row[columnName].ToString();
        }

        public static string GetString(this DataRow row, int columnIndex, string defaultValue = null)
        {
            return row.IsNull(columnIndex) ? defaultValue : row[columnIndex].ToString();
        }

        public static T GetStruct<T>(this DataRow row, string columnName, T defaultValue = default(T))
            where T : struct
        {
            return row.IsNull(columnName) ? defaultValue : (T)row[columnName];
        }

        public static T? GetNullableStruct<T>(this DataRow row, string columnName, T? defaultValue = null)
            where T : struct
        {
            if (row.IsNull(columnName))
            {
                return defaultValue;
            }

            if (row[columnName] is T?)
            {
                return row[columnName] as T?;
            }

            return defaultValue;
        }

        public static T GetStruct<T>(this DataRow row, int columnIndex, T defaultValue = default(T))
            where T : struct
        {
            return row.IsNull(columnIndex) ? defaultValue : (T)row[columnIndex];
        }

        public static T? GetNullableStruct<T>(this DataRow row, int columnIndex, T? defaultValue = null)
            where T : struct
        {
            if (row.IsNull(columnIndex))
            {
                return defaultValue;
            }

            if (row[columnIndex] is T?)
            {
                return row[columnIndex] as T?;
            }

            return defaultValue;
        }

        public static IList<T> Map<T>(this DataTable dataTable)
            where T : new()
        {
            return DbMapperUtil.Map<T>(dataTable);
        }

        public static IList<T> MapValue<T>(this DataTable dataTable)
        {
            return DbMapperUtil.MapValue<T>(dataTable);
        }

        public static void MapTo(this DataTable dataTable, object target)
        {
            DbMapperUtil.MapTo(dataTable, target);
        }

        public static void MapTo<T>(this DataTable dataTable, ref IList<T> list)
            where T : new()
        {
            DbMapperUtil.Map<T>(dataTable, ref list);
        }
    }
}
