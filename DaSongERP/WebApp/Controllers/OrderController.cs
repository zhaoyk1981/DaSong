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
            var vm = this.OrderBiz.GetEditOrderViewModel();
            return View(vm);
        }

        [HttpPost]
        public ActionResult ACreate()
        {
            var order = this.DeserializeObject<OrderModel>(Request.Params["FormJson"]);
            var rowCount = this.OrderBiz.CreateOrder(order);
            if (rowCount == 1)
            {
                Request.Files[0].SaveAs($"{this.OrderBiz.GetProductImagesPath()}\\{order.ID.Value}.jpg");
            }

            return Json(new
            {
                Success = rowCount == 1,
                OrderID = order.ID.Value.ToString()
            });
        }
    }
}