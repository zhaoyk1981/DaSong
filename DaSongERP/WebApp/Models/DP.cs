using DaSongERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DaSongERP.WebApp.Models
{
    public static class DP
    {
        public static string Txt(DateTime? dt, string format = "yyyy-MM-dd HH:mm", string dflt = "无")
        {
            return dt.HasValue ? dt.Value.ToString(format) : dflt;
        }

        public static string Txt(string s, string dflt = "无", bool raw = false)
        {
            var v = string.IsNullOrWhiteSpace(s) ? dflt : s.Trim();
            if (raw)
            {
                v = HttpUtility.HtmlEncode(v).Replace("\r\n", "<br/>");
            }

            return v;
        }

        public static string Txt(bool? b, string t = "是", string f = "否", string dflt = "无")
        {
            return b.HasValue ? (b.Value ? t : f) : dflt;
        }

        public static string Txt(decimal? dec, string format = "c2", string dflt = "无")
        {
            return dec.HasValue ? dec.Value.ToString(format) : dflt;
        }

        public static string Txt(int? num, string dflt = "无")
        {
            return num.HasValue ? num.Value.ToString() : dflt;
        }

        public static string Txt(MetaModel<Guid> m, string dflt = "无")
        {
            return string.IsNullOrEmpty(m?.Name) ? dflt : m.Name.Trim();
        }

        public static string Txt(UserModel u, string dflt = "无")
        {
            return string.IsNullOrEmpty(u?.Name) ? dflt : u.Name.Trim();
        }

        public static string Baidu(string str, string dflt = "无")
        {
            if (string.IsNullOrEmpty(str))
            {
                return dflt;
            }

            return $"<a href=\"https://www.baidu.com/s?wd={str}\" target=\"_blank\">{str}</a>";
        }
    }
}