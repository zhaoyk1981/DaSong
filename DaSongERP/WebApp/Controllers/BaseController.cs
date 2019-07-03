using DaSongERP.Biz;
using DaSongERP.Models;
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
        protected UserBiz UserBiz { get; set; } = new UserBiz();

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

        /// <summary>
        /// Gets or sets the logged account identifier.
        /// </summary>
        /// <value>
        /// The logged account identifier.
        /// </value>
        protected Guid? UserID
        {
            get
            {
                var cookie = this.Request.Cookies["UserID"];
                Guid id;
                if (!string.IsNullOrWhiteSpace(cookie?.Value) && Guid.TryParse(cookie.Value, out id))
                {
                    return id;
                }

                return null;
            }
        }

        protected void SetLoggedInUserId(Guid? id = null, bool rememberMe = true)
        {
            var cookie = new HttpCookie("UserID", id.GetValueOrDefault().ToString());

            if (id.HasValue)
            {
                if (rememberMe)
                {
                    cookie.Expires = DateTime.Now.AddHours(8);
                }
            }
            else
            {
                // 注销用户
                cookie.Expires = DateTime.Now.AddDays(-1);
            }

            this.Response.Cookies.Remove("UserID");
            this.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// The logged account
        /// </summary>
        private UserModel _loggedAccount = null;

        /// <summary>
        /// Gets or sets the logged account.
        /// </summary>
        /// <value>
        /// The logged account.
        /// </value>
        protected virtual UserModel LoggedAccount
        {
            get
            {
                if (!this.UserID.HasValue)
                {
                    _loggedAccount = null;
                    return null;
                }

                if (_loggedAccount == null || _loggedAccount.ID.GetValueOrDefault() != this.UserID.Value)
                {
                    _loggedAccount = this.UserBiz.GetUserBy(this.UserID.Value);
                }

                return _loggedAccount;
            }
            set
            {
                _loggedAccount = value;
            }
        }

        protected void _SignOut()
        {
            this.SetLoggedInUserId();
        }
    }
}