using DaSongERP.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DaSongERP.Models;
using DaSongERP.ViewModels;

namespace DaSongERP.WebApp.Controllers
{
    public class SignInController : BaseController
    {
        
        // GET: SignIn
        public ActionResult Index()
        {
            var vm = this.UserBiz.GetSignInViewModel();
            return View(vm);
        }

        [HttpPost]
        public ActionResult AValidateUser()
        {
            var user = this.DeserializeObject<UserModel>(Request.Params["FormJson"]);
            var result = this.UserBiz.ValidateUser(user);
            if (result != null)
            {
                this.SetLoggedInUserId(result.ID);
            }

            return Json(new
            {
                Success = result != null,
                ReturnUrl = "/Default"
            });
        }
    }
}