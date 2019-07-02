using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.Caching;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace YK
{
    public static class SystemExtendMethods
    {
        private static readonly DateTime JS_BEGIN_DATE = new DateTime(1970, 1, 1);

        public static long GetTime(this DateTime end)
        {
            return Convert.ToInt64(Math.Ceiling(end.Subtract(JS_BEGIN_DATE).TotalMilliseconds));
        }

        public static DateTime ToDate(this long ms)
        {
            return JS_BEGIN_DATE.AddMilliseconds(ms);
        }

        public static bool CompareFlag(this ulong flag, ulong compareFlag, ulong ignoreFlag)
        {
            var f = flag - (flag & ignoreFlag);
            return f == compareFlag;
        }

        public static bool IsSameType(this Type type, Type compType)
        {
            do
            {
                if (type.FullName == compType.FullName)
                {
                    return true;
                }

                if (compType.Name == "Nullable`1" && type.IsSameType(compType.GenericTypeArguments.Single()))
                {
                    return true;
                }

                if (type.Name == "Nullable`1" && compType.IsSameType(type.GenericTypeArguments.Single()))
                {
                    return true;
                }
            } while (false);

            return false;
        }

        public static Type GetNullableTypeArgument(this Type type)
        {
            if (type.Name == "Nullable`1")
            {
                return type.GenericTypeArguments.FirstOrDefault();
            }

            return type;
        }

        public static object TryChangeType(this object source, Type targetType)
        {
            if (source == null)
            {
                return null;
            }

            var sourceType = source.GetType();
            if (sourceType.IsSameType(targetType))
            {
                return source;
            }

            if (targetType.GetNullableTypeArgument().FullName == typeof(Guid).FullName && sourceType.FullName == typeof(string).FullName)
            {
                return (source as string).TryParseStruct<Guid>();
            }

            if ((sourceType.Name == "List`1" || sourceType.Name == "IList`1") && targetType.FullName == typeof(DataTable).FullName)
            {
                var dt = new DataTable();
                dt.Columns.Add("Id", sourceType.GenericTypeArguments[0]);
                var list = source as System.Collections.ICollection;
                foreach (object item in list)
                {
                    var row = dt.NewRow();
                    row[0] = item;
                    dt.Rows.Add(row);
                }

                return dt;
            }
            else if (sourceType.Name == "String[]")
            {
                var dt = new DataTable();
                dt.Columns.Add("Id", typeof(string));
                var list = source as System.Collections.ICollection;
                foreach (object item in list)
                {
                    var row = dt.NewRow();
                    row[0] = item;
                    dt.Rows.Add(row);
                }

                return dt;
            }
            else if ((sourceType.Name == "Dictionary`2" || sourceType.Name == "IDictionary`2") && targetType.FullName == typeof(DataTable).FullName)
            {
                var dt = new DataTable();
                dt.Columns.Add("Key", sourceType.GenericTypeArguments[0]);
                dt.Columns.Add("Value", sourceType.GenericTypeArguments[1]);
                var list = source as System.Collections.ICollection;
                foreach (object item in list)
                {
                    var row = dt.NewRow();
                    var itemType = item.GetType();
                    row[0] = itemType.GetProperty("Key").GetValue(item);
                    row[1] = itemType.GetProperty("Value").GetValue(item);
                    dt.Rows.Add(row);
                }

                return dt;
            }

            return Convert.ChangeType(source, targetType.GetNullableTypeArgument());
        }

        private static ObjectCache propertyInfoCache = new MemoryCache("PropertyInfo");

        public static PropertyInfo GetPropertyInfo(this Type type, string name)
        {
            var props = propertyInfoCache.Get(type.FullName) as PropertyInfo[];
            if (props == null)
            {
                props = type.GetProperties();
                propertyInfoCache.Add(new CacheItem(type.FullName, props), new CacheItemPolicy()
                {
                    SlidingExpiration = new TimeSpan(1, 0, 0) // 1 hour
                });
            }

            return props.SingleOrDefault(m => string.Compare(m.Name, name, true) == 0);
        }

        public static IList<int> Extract(this Enum flags)
        {
            var list = new List<int>();
            var values = Enum.GetValues(flags.GetType());
            foreach (var v in values)
            {
                var intVal = Convert.ToInt32(v);
                if ((Convert.ToInt32(flags) & intVal) == intVal)
                {
                    list.Add(intVal);
                }
            }

            return list;
        }

        public static string HtmlEncode2(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }

            var s = str;
            return s.Replace(" ", "&nbsp;")
                .Replace("\r\n", "<br/>")
                .Replace("\r", "<br/>")
                .Replace("\n", "<br/>");
        }

        public static string HtmlEncodeEdit(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }

            var s = str;

            return HttpContext.Current.Server.HtmlEncode(s);
        }

        public static T? TryParseStruct<T>(this string str)
            where T : struct
        {
            if (string.IsNullOrEmpty(str))
            {
                return default(T?);
            }

            try
            {
                if (typeof(T).FullName == typeof(Guid).FullName)
                {
                    return Guid.Parse(str) as T?;
                }

                return (T?)Convert.ChangeType(str, typeof(T));
            }
            catch
            {
            }

            return default(T?);
        }

        public static string MessageWithInner(this Exception exception)
        {
            var ex = exception;
            var b = new StringBuilder();
            while (ex != null)
            {
                b.AppendLine(ex.Message);
                ex = ex.InnerException;
            }

            return b.ToString();
        }

        public static string StackTraceWithInner(this Exception exception)
        {
            var ex = exception;
            var b = new StringBuilder();
            while (ex != null)
            {
                b.AppendLine(ex.StackTrace);
                ex = ex.InnerException;
            }

            return b.ToString();
        }

        public static string ValueOrNull(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }

            return str;
        }

        public static T? ValueOrNull<T>(this T? value)
            where T : struct
        {
            if (value.GetValueOrDefault().Equals(default(T)))
            {
                return null;
            }

            return value;
        }

        public static bool HasFlag(this long source, long flag, bool zero = false)
        {
            if (flag == 0L)
            {
                return zero;
            }

            return (source & Math.Abs(flag)) == Math.Abs(flag);
        }

        public static Int64 AddFlag(this long source, long flag)
        {
            if (flag == 0L)
            {
                return source;
            }

            if (source.HasFlag(flag, false))
            {
                return flag > 0 ? source : source + flag;
            }

            return flag > 0 ? source + flag : source;
        }

        public static string Substr(this string str, int startIndex, int length = -1)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }

            startIndex = Math.Max(startIndex, 0);

            if (str.Length <= startIndex)
            {
                return string.Empty;
            }

            if (length < 0 || str.Length < startIndex + length)
            {
                return str.Substring(startIndex);
            }

            return str.Substring(startIndex, length);
        }

        public static string Right(this string str, int length)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }

            return str.Substr(str.Length - length, length);
        }

        public static string Left(this string str, int length)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }

            return str.Substr(0, length);
        }
    }
}
