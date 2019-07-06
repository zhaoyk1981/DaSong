
using DaSongERP.Dal;
using DaSongERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DaSongERP.Biz
{
    public class Biz
    {
        protected MetaDao MetaDao { get; set; } = new MetaDao();

        protected UserDao UserDao { get; set; } = new UserDao();

        protected OrderDao OrderDao { get; set; } = new OrderDao();

        protected ExcelDao ExcelDao { get; set; } = new ExcelDao();

        protected Guid? UserID
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
    }
}
