using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DaSongERP.WebApp.Controllers
{
    public class SignOutController : BaseController
    {
        // GET: SignOut
        public ActionResult Index()
        {
            _SignOut();
            return Redirect("/SignIn");
        }
    }
}