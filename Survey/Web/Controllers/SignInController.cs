using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Bizs;
using Web.Models;

namespace Web.Controllers
{
    public class SignInController : DefaultController
    {
        private SignInBiz SignInBiz { get; set; } = new SignInBiz();
        // GET: SignIn
        public ActionResult Index()
        {
            var vm = this.SignInBiz.GetViewModel();
            return View(vm);
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult SignIn()
        {
            var user = Newtonsoft.Json.JsonConvert.DeserializeObject<UserModel>(Request.Params["ModelJson"]);
            return Json(new { });
        }
    }
}