﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DaSongERP.WebApp.Controllers
{
    public class DefaultController : AuthorizedController
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
    }
}