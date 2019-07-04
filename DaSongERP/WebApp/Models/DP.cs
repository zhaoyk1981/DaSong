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

        public static string Txt(string s, string dflt = "无")
        {
            return string.IsNullOrWhiteSpace(s) ? dflt : s.Trim();
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

        public static string Txt(MetaModel m, string dflt = "无")
        {
            return string.IsNullOrEmpty(m?.Name) ? dflt : m.Name.Trim();
        }

        public static string Txt(UserModel u, string dflt = "无")
        {
            return string.IsNullOrEmpty(u?.Name) ? dflt : u.Name.Trim();
        }
    }
}