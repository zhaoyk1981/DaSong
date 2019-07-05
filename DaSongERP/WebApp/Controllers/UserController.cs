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
            return View();
        }
    }
}