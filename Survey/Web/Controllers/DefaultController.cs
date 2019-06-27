using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class DefaultController : Controller
    {
        public UserModel CurrentUser
        {
            get
            {
                return Session["CurrentUser"] as UserModel;
            }
            set
            {
                Session["CurrentUser"] = value;
            }
        }
    }
}