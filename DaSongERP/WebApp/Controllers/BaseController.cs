using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class BaseController : Controller
    {
        private static string _BuildVer;
        /// <summary>
        /// Build版本，用于防止客户端JS和CSS文件缓存，没次Build时重新生成
        /// </summary>
        public static string BuildVer
        {
            get
            {
                if (string.IsNullOrEmpty(_BuildVer))
                {
                    _BuildVer = Guid.NewGuid().ToString().Replace("-", "");
                }

                return _BuildVer;
            }
        }


        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            ViewData["BuildVer"] = BuildVer;
#if DEBUG
            ViewData["DEBUG"] = "DEBUG";
#endif
            base.OnActionExecuted(filterContext);
        }

        protected T DeserializeObject<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }

        protected string SerializeObject(object value)
        {
            return JsonConvert.SerializeObject(value);
        }

        protected string ReturnUrl
        {
            get
            {
                return this.Session["ReturnUrl"] as string;
            }
            set
            {
                this.Session["ReturnUrl"] = value;
            }
        }
    }
}