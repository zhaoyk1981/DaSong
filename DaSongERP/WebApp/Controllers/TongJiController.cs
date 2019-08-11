using DaSongERP.Conditions;
using DaSongERP.Models;
using DaSongERP.WebApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YK;

namespace DaSongERP.WebApp.Controllers
{
    public class TongJiController : AuthorizedController
    {
        public ActionResult ChaiBao()
        {
            if (!PM.Any(UPM.拆包))
            {
                return Redirect("/SignIn");
            }

            var vm = this.统计Biz.统计拆包审单数量();
            return View(vm);
        }
    }
}