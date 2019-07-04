using DaSongERP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class OrderController : AuthorizedController
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            var vm = this.OrderBiz.GetCreateOrderViewModel();
            return View(vm);
        }

        [HttpPost]
        public ActionResult ACreate()
        {
            var order = this.DeserializeObject<OrderModel>(Request.Params["FormJson"]);
            var rowCount = this.OrderBiz.Create(order);
            //if (rowCount == 1)
            //{
            //    Request.Files[0].SaveAs($"{this.OrderBiz.GetProductImagesPath()}\\{order.ID.Value}.jpg");
            //}

            return Json(new
            {
                Success = rowCount == 1,
                OrderID = order.ID.Value.ToString()
            });
        }

        [HttpPost]
        public ActionResult AGetOrderID()
        {
            var jd订单号 = (this.Request.Params["jdoid"] ?? string.Empty).Trim();
            if (string.IsNullOrEmpty(jd订单号))
            {
                return Json(new
                {
                    Success = false
                });
            }

            var order = this.OrderBiz.GetOrderBy(jd订单号);
            return Json(new
            {
                Success = order != null,
                OrderID = order == null ? null : order.ID.Value.ToString()
            });
        }

        public ActionResult Edit(Guid id)
        {
            var vm = this.OrderBiz.GetEditOrderViewModel(id);
            if (vm.Order == null)
            {
                return Redirect("/Order");
            }

            return View(vm);
        }

        [HttpPost]
        public ActionResult AUpdate()
        {
            var order = this.DeserializeObject<OrderModel>(Request.Params["FormJson"]);
            var rowCount = this.OrderBiz.Update(order);

            return Json(new
            {
                Success = rowCount == 1
            });
        }

        public ActionResult GenJin(Guid id)
        {
            var vm = this.OrderBiz.GetEditOrderViewModel(id);
            if (vm.Order == null)
            {
                return Redirect("/Order");
            }

            return View(vm);
        }

        [HttpPost]
        public ActionResult AGenJin()
        {
            var order = this.DeserializeObject<OrderModel>(Request.Params["FormJson"]);
            var rowCount = this.OrderBiz.订单跟进(order);

            return Json(new
            {
                Success = rowCount == 1
            });
        }
    }
}