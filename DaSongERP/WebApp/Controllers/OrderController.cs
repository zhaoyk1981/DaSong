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

        public ActionResult Import()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AImport()
        {
            var excelStream = this.Request.Files[0].InputStream;
            bool isXlsx = string.Compare(Path.GetExtension(this.Request.Files[0].FileName), ".xlsx", true) == 0;
            var file = OrderBiz.电话客服导入(excelStream, isXlsx);
            var 未导入 = OrderBiz.Count未导入();
            return Json(new
            {
                Success = true,
                Url = $"/Excel/{file}",
                未导入 = 未导入
            });
        }

        public ActionResult ChaiBao(Guid id)
        {
            var vm = this.OrderBiz.GetChaiBaoOrderViewModel(id);
            if (vm.Order == null)
            {
                return Redirect("/Order");
            }

            return View(vm);
        }

        [HttpPost]
        public ActionResult AChaiBao()
        {
            var order = this.DeserializeObject<OrderModel>(Request.Params["FormJson"]);
            var rowCount = this.OrderBiz.Update拆包(order);

            return Json(new
            {
                Success = rowCount == 1
            });
        }
    }
}