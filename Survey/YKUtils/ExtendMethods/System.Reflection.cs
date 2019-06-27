using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace YK
{
    public static class SystemReflectionExtendMethods
    {
        public static bool TrySetValue(this PropertyInfo prop, object obj, object value)
        {
            if (!prop.CanWrite)
            {
                return false;
            }

            object cvValue = null;
            try
            {
                if (value != null)
                {
                    cvValue = value.TryChangeType(prop.PropertyType);
                }

                prop.SetValue(obj, cvValue);
                return true;
            }
            catch { }

            return false;
        }


    }
}
