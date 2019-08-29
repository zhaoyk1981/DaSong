using DaSongERP.Conditions;
using DaSongERP.Models;
using DaSongERP.ViewModels;
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

            //var vm = this.统计Biz.统计拆包审单数量();
            return View(new 拆包审单统计ViewModel());
        }

        [HttpPost]
        public ActionResult AChaiBaoByDay()
        {
            var condition = this.DeserializeObject<统计Condition>(Request.Params["FormJson"]);
            var vm = this.统计Biz.统计日拆包审单数量(condition.Date);
            return Json(new
            {
                By员工 = vm.By员工,
                By状态 = vm.By状态
            });
        }

        [HttpPost]
        public ActionResult AChaiBaoByMonth()
        {
            var condition = this.DeserializeObject<统计Condition>(Request.Params["FormJson"]);
            var vm = this.统计Biz.统计月拆包审单数量(condition.Date);
            return Json(new
            {
                By员工 = vm.By员工,
                By状态 = vm.By状态
            });
        }

        public ActionResult CaiGou()
        {
            if (!PM.Any(UPM.管理))
            {
                return Redirect("/SignIn");
            }

            return View(new 拆包审单统计ViewModel());
        }

        [HttpPost]
        public ActionResult ACaiGouByDay()
        {
            var condition = this.DeserializeObject<统计Condition>(Request.Params["FormJson"]);
            var vm = this.统计Biz.统计日采购订单(condition.Date);
            return Json(new
            {
                By中转仓 = vm.By中转仓,
                By状态 = vm.By状态,
                By员工 = vm.By员工
            });
        }

        [HttpPost]
        public ActionResult ACaiGouByMonth()
        {
            var condition = this.DeserializeObject<统计Condition>(Request.Params["FormJson"]);
            var vm = this.统计Biz.统计月采购订单(condition.Date);
            return Json(new
            {
                By中转仓 = vm.By中转仓,
                By状态 = vm.By状态,
                By员工 = vm.By员工
            });
        }
    }
}