using DaSongERP.Models;
using DaSongERP.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DaSongERP.WebApp.Controllers
{
    public class UserController : AuthorizedController
    {
        // GET: User
        public ActionResult Index()
        {
            if (!PM.Any(UPM.管理))
            {
                return Redirect("/SignIn");
            }

            var vm = this.UserBiz.GetUserListViewModel(this.Request.QueryString["search"]);
            return View(vm);
        }

        [HttpPost]
        public ActionResult ARemove()
        {
            if (!PM.Any(UPM.管理))
            {
                return this.Json(new
                {
                    Success = false
                });
            }

            var id = Guid.Parse(Request.Params["ID"]);
            var rowCount = this.UserBiz.RemoveUser(id);
            return Json(new
            {
                Success = rowCount == 1
            });
        }

        public ActionResult New()
        {
            if (!PM.Any(UPM.管理))
            {
                return Redirect("/SignIn");
            }

            var vm = UserBiz.GetNewUserViewModel();
            return View(vm);
        }

        [HttpPost]
        public ActionResult ACreate()
        {
            if (!PM.Any(UPM.管理))
            {
                return this.Json(new
                {
                    Success = false
                });
            }

            var user = this.DeserializeObject<UserModel>(Request.Params["FormJson"]);
            var result = this.UserBiz.Create(user);
            return Json(new
            {
                Success = result == 1,
                ErrorMessage = result == 2 ? "用户名已存在" : string.Empty,
                ID = user.ID
            });
        }

        public ActionResult Edit(Guid id)
        {
            if (!PM.Any(UPM.管理))
            {
                return Redirect("/SignIn");
            }

            var vm = UserBiz.GetEditUserViewModel(id);
            return View(vm);
        }

        [HttpPost]
        public ActionResult AUpdate()
        {
            if (!PM.Any(UPM.管理))
            {
                return this.Json(new
                {
                    Success = false
                });
            }

            var user = this.DeserializeObject<UserModel>(Request.Params["FormJson"]);
            var result = this.UserBiz.Update(user);
            if (user.ID.Value == UserID.Value)
            {
                this.LoggedAccount = null;
            }

            return Json(new
            {
                Success = result == 1,
                ErrorMessage = result == 2 ? "用户名已存在" : string.Empty,
                ID = user.ID
            });
        }
    }
}