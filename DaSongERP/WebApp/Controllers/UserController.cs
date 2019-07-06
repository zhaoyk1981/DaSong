using DaSongERP.Models;
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
            var vm = this.UserBiz.GetUserListViewModel(this.Request.QueryString["search"]);
            return View(vm);
        }

        [HttpPost]
        public ActionResult ARemove()
        {
            var id = Guid.Parse(Request.Params["ID"]);
            var rowCount = this.UserBiz.RemoveUser(id);
            return Json(new
            {
                Success = rowCount == 1
            });
        }

        public ActionResult New()
        {
            var vm = UserBiz.GetNewUserViewModel();
            return View(vm);
        }

        [HttpPost]
        public ActionResult ACreate()
        {
            var user = this.DeserializeObject<UserModel>(Request.Params["FormJson"]);
            var result = this.UserBiz.Create(user);
            return Json(new
            {
                Success = result == 1,
                ErrorMessage = result == 2 ? "用户名已存在" : string.Empty,
                ID = user.ID
            });
        }


    }
}