using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DianBaTaoBao.Models
{
    public class ConvertHelper
    {
        public static int? ToInt(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return null;
            }

            var s = str.Replace(",", "");
            if (int.TryParse(s, out int val))
            {
                return val;
            }

            return null;
        }

        public static decimal? ToDecimal(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return null;
            }

            var s = str.Replace(",", "").Replace("¥", "").Replace(" ", "");
            if (decimal.TryParse(s, out decimal val))
            {
                return val;
            }

            return null;
        }

        public static string ToDispStr(int? source)
        {
            if (!source.HasValue)
            {
                return "N/A";
            }

            return source.ToString();
        }

        public static string ToDispStr(decimal? source)
        {
            if (!source.HasValue)
            {
                return "N/A";
            }

            return source.ToString();
        }

        public static string ToDispStr(string source)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                return "N/A";
            }

            return source;
        }
    }
}
