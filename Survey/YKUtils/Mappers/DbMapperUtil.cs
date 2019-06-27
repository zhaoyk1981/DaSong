using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace YK.Mappers
{
    public class DbMapperUtil
    {
        public static IList<T> Map<T>(DataTable dataTable)
            where T : new()
        {
            var propNames = GetPropNames(dataTable);
            var list = new List<T>();
            foreach (DataRow row in dataTable.Rows)
            {
                var t = new T();
                list.Add(t);
                foreach (var propName in propNames)
                {
                    TrySetValue(t, propName, row[propName]);
                }
            }

            return list;
        }

        public static IList<T> MapValue<T>(DataTable dataTable)
        {
            var list = new List<T>();
            foreach (DataRow row in dataTable.Rows)
            {
                list.Add(ConvertValue<T>(row[0]));
            }

            return list;
        }

        private static T ConvertValue<T>(object sourceValue)
        {
            if (sourceValue == null || sourceValue == DBNull.Value)
            {
                return default(T);
            }

            return (T)sourceValue;
        }

        public static IList<Guid> MapGuidList(DataTable dataTable)
        {
            var list = new List<Guid>();
            foreach (DataRow row in dataTable.Rows)
            {
                list.Add((row[0] as Guid?).GetValueOrDefault());
            }

            return list;
        }

        public static void Map<T>(DataTable dataTable, ref IList<T> list)
            where T : new()
        {
            var propNames = GetPropNames(dataTable);
            list = list ?? new List<T>();
            for (var i = 0; i < dataTable.Rows.Count; i++)
            {
                var row = dataTable.Rows[i];
                var t = list.ElementAtOrDefault(i);
                if (t == null)
                {
                    t = new T();
                    list.Insert(i, t);
                }

                for (var j = 0; j < propNames.Length; j++)
                {
                    TrySetValue(t, propNames[j], row[propNames[j]]);
                }
            }
        }

        private static bool TrySetValue(object target, string propName, object value)
        {
            value = value is DBNull ? default(object) : value;
            var propNameSplited = propName.Split(".".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var setTarget = TryFindTarget(target, propNameSplited, 0);
            if (setTarget == null)
            {
                return false;
            }

            var prop = setTarget.GetType().GetPropertyInfo(propNameSplited.Last());
            if (prop == null || !prop.CanWrite)
            {
                return false;
            }

            if ((value as int? != null) && (prop.PropertyType.Name == "Boolean" || (prop.PropertyType.GenericTypeArguments.Length == 1 && prop.PropertyType.GenericTypeArguments.First().Name == "Boolean")))
            {
                prop.SetValue(setTarget, (value as int?).GetValueOrDefault() == 1);
                return true;
            }

            prop.SetValue(setTarget, value);
            return true;
        }

        private static object TryFindTarget(object target, string[] propNameSplited, int level)
        {
            if (propNameSplited.Length - 1 == level)
            {
                return target;
            }

            var prop = target.GetType().GetPropertyInfo(propNameSplited[level]);
            if (prop == null)
            {
                return null;
            }

            var newTarget = prop.GetValue(target);
            if (newTarget == null)
            {
                //throw new Exception("The value in path is null. Path: " + string.Join(".", propNameSplited.Take(level + 1)));
                return null;
            }

            return TryFindTarget(newTarget, propNameSplited, level + 1);
        }

        private static string[] GetPropNames(DataTable dataTable)
        {
            var names = new List<string>();
            for (var i = 0; i < dataTable.Columns.Count; i++)
            {
                names.Add(dataTable.Columns[i].ColumnName);
            }

            names = names.OrderBy(m => m.ToCharArray().Count(n => n == '.')).ThenBy(m => m).ToList();
            return names.ToArray();
        }

        public static int MapTo<T>(DataTable dataTable, IList<T> dataSource)
        {
            if (dataTable == null)
            {
                throw new ArgumentNullException("dataTable");
            }

            if (dataSource == null)
            {
                return 0;
            }

            var count = 0;

            foreach (T model in dataSource)
            {
                DataRow r = dataTable.NewRow();
                bool hasValue = false;
                foreach (DataColumn col in dataTable.Columns)
                {
                    var propName = col.ColumnName;
                    var prop = model.GetType().GetPropertyInfo(propName);
                    if (prop == null)
                    {
                        continue;
                    }

                    r[propName] = prop.GetValue(model);
                    hasValue = true;
                }

                if (hasValue)
                {
                    dataTable.Rows.Add(r);
                    count++;
                }
            }

            return count;
        }

        public static void MapTo(DataTable dataTable, object target)
        {
            if (dataTable == null)
            {
                throw new ArgumentNullException("dataTable");
            }

            if (target == null)
            {
                return;
            }

            if (dataTable.Rows.Count == 0)
            {
                throw new ArgumentException("No row in data table.");
            }

            DataRow r = dataTable.Rows[0];
            foreach (DataColumn col in dataTable.Columns)
            {
                var propName = col.ColumnName;

                PropertyInfo prop = target.GetType().GetPropertyInfo(propName);
                if (prop == null)
                {
                    continue;
                }

                object value = r.IsNull(propName) ? default(Object) : r[propName];
                prop.TrySetValue(target, value);
            }
        }
    }
}
