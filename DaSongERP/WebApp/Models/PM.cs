using DaSongERP.Biz;
using DaSongERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DaSongERP.WebApp.Models
{
    public static class PM
    {
        public static Guid? UserID
        {
            get
            {
                var cookie = HttpContext.Current.Request.Cookies["UserID"];
                Guid id;
                if (!string.IsNullOrWhiteSpace(cookie?.Value) && Guid.TryParse(cookie.Value, out id))
                {
                    return id;
                }

                return null;
            }
        }

        public static UserModel User
        {
            get
            {
                return HttpContext.Current.Session["SessionUser"] as UserModel;
            }
        }

        public static bool Any(params UPM[] ps)
        {
            if (User?.PermissionID.GetValueOrDefault() == 0)
            {
                return false;
            }

            foreach (var p in ps)
            {
                if ((User.PermissionID.Value & (int)p) == (int)p)
                {
                    return true;
                }
            }

            return false;
        }
    }
}