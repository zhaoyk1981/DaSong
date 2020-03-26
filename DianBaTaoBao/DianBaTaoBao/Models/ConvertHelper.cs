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

        public static int? ToInt2(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return null;
            }

            var s = str.Replace(",", "")
                .Replace("人收货", "")
                .Replace("+", "")
                .Replace(" ", "");
            var x = 1;
            if (s.IndexOf("万") >= 0)
            {
                x = 10000;
            }
            else if (s.IndexOf("千") >= 0)
            {
                x = 1000;
            }

            s = s.Replace("万", "")
                .Replace("千", "");

            if (decimal.TryParse(s, out decimal val))
            {
                return Convert.ToInt32(val * x);
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

        public static object ToDispStr(int? source)
        {
            if (!source.HasValue)
            {
                return "N/A";
            }

            return source.Value;
        }

        public static object ToDispStr(decimal? source)
        {
            if (!source.HasValue)
            {
                return "N/A";
            }

            return source.Value;
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
