using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace YK
{
    public static class SystemCollectionsSpecializedExtendMethods
    {
        public static T Map<T>(this NameValueCollection collection)
            where T : class, new()
        {
            T obj = new T();

            for (var i = 0; i < collection.AllKeys.Length; i++)
            {
                var propName = collection.AllKeys[i];
                var strValue = collection[propName];
                PropertyInfo prop = obj.GetType().GetPropertyInfo(propName);
                if (prop == null)
                {
                    continue;
                }

                prop.TrySetValue(obj, strValue);
            }

            return obj;
        }

        public static void MapTo<T>(this NameValueCollection collection, T obj)
            where T : class, new()
        {
            if (obj == null)
            {
                return;
            }

            for (var i = 0; i < collection.AllKeys.Length; i++)
            {
                var propName = collection.AllKeys[i];
                var strValue = collection[propName];
                PropertyInfo prop = obj.GetType().GetPropertyInfo(propName);
                if (prop == null)
                {
                    continue;
                }

                prop.TrySetValue(obj, strValue);
            }
        }
    }
}
