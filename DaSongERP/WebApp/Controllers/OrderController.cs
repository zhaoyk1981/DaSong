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
    public class OrderController : AuthorizedController
    {
        public ActionResult Index()
        {
            if (!PM.Any(UPM.售后, UPM.客服, UPM.跟进, UPM.采购))
            {
                return Redirect("/SignIn");
            }

            var jd订单号 = (Request.QueryString["search"] ?? string.Empty).Trim();
            var vm = this.OrderBiz.GetOrderListViewModel(jd订单号);
            return View(vm);
        }

        public ActionResult New()
        {
            if (!PM.Any(UPM.采购))
            {
                return Redirect("/SignIn");
            }

            var vm = this.OrderBiz.GetCreateOrderViewModel();
            return View(vm);
        }

        [HttpPost]
        public ActionResult ACreate()
        {
            if (!PM.Any(UPM.采购))
            {
                return Json(new
                {
                    Success = false
                });
            }

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

        public ActionResult ChaiBaoList()
        {
            if (!PM.Any(UPM.拆包))
            {
                return Redirect("/SignIn");
            }

            var 来快递单号 = (Request.QueryString["search"] ?? string.Empty).Trim();
            var vm = this.OrderBiz.GetChaiBaoOrderListViewModel(来快递单号);
            return View(vm);
        }

        [HttpPost]
        public ActionResult AGetOrderID()
        {
            //var jd订单号 = (this.Request.Params["jdoid"] ?? string.Empty).Trim();
            var 来快递单号 = (this.Request.Params["来快递单号"] ?? string.Empty).Trim();
            if (string.IsNullOrEmpty(来快递单号))
            {
                return Json(new
                {
                    ID = string.Empty
                });
            }

            var orders = this.OrderBiz.GetOrdersBy来快递单号(来快递单号);
            if (orders.Count == 1)
            {
                return Json(new
                {
                    ID = orders[0].ID.Value.ToString()
                });
            }

            return Json(new
            {
                ID = string.Empty
            });
        }

        [HttpPost]
        public ActionResult AHasOrder()
        {
            var order = this.DeserializeObject<OrderModel>(Request.Params["FormJson"]);
            var result = this.OrderBiz.GetOrderBy订单号(order);
            return Json(new
            {
                HasOrder = result != null
            });
        }

        public ActionResult Edit(Guid id)
        {
            if (!PM.Any(UPM.采购))
            {
                return Redirect("/SignIn");
            }

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
            if (!PM.Any(UPM.采购))
            {
                return Json(new
                {
                    Success = false
                });
            }

            var order = this.DeserializeObject<OrderModel>(Request.Params["FormJson"]);
            var rowCount = this.OrderBiz.Update(order);

            return Json(new
            {
                Success = rowCount == 1
            });
        }

        public ActionResult GenJin(Guid id)
        {
            if (!PM.Any(UPM.跟进))
            {
                return Redirect("/SignIn");
            }

            var vm = this.OrderBiz.Get跟进ViewModel(id);
            if (vm.Order == null)
            {
                return Redirect("/Order");
            }

            return View(vm);
        }

        [HttpPost]
        public ActionResult AGenJin()
        {
            if (!PM.Any(UPM.跟进))
            {
                return Json(new
                {
                    Success = false
                });
            }

            var order = this.DeserializeObject<OrderModel>(Request.Params["FormJson"]);
            var rowCount = this.OrderBiz.订单跟进(order);

            return Json(new
            {
                Success = rowCount == 1
            });
        }

        public ActionResult Import()
        {
            if (!PM.Any(UPM.电话))
            {
                return Redirect("/SignIn");
            }

            var vm = this.OrderBiz.Get电话客服ListViewModel();
            vm.Json = SerializeObject(new
            {
                AllIDs = new string[] { },
                currentSortPaging = vm.Orders.GetCurrentSortPaging()
            });
            return View(vm);
        }

        [HttpPost]
        public ActionResult AImport()
        {
            if (!PM.Any(UPM.电话))
            {
                return Json(new
                {
                    Success = false
                });
            }

            var excelStream = this.Request.Files[0].InputStream;
            var ext = Path.GetExtension(this.Request.Files[0].FileName).ToLower();
            if (ext != ".xlsx" && ext != ".xls")
            {
                return Json(new
                {
                    Success = false,
                    ErrorMessage = $"不支持 {ext} 文件"
                });
            }

            bool isXlsx = string.Compare(Path.GetExtension(this.Request.Files[0].FileName), ".xlsx", true) == 0;
            var file = OrderBiz.电话客服导入(excelStream, isXlsx);
            var 未导入 = OrderBiz.Get未导入Orders().Count;
            return Json(new
            {
                Success = true,
                Url = $"/Excel/{file}",
                未导入 = 未导入
            });
        }

        [HttpPost]
        public ActionResult ADianHuaKeFuList()
        {
            var condition = this.Request.Params.Map<OrderCondition>();
            condition.PageIndex = int.Parse(this.Request.Params["PageIndex"]);

            var list = this.OrderBiz.Get电话客服List(condition);
            return this.Json(list);
        }

        public ActionResult ChaiBao(Guid id)
        {
            if (!PM.Any(UPM.拆包))
            {
                return Redirect("/SignIn");
            }

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
            if (!PM.Any(UPM.拆包))
            {
                return Json(new
                {
                    Success = false
                });
            }

            var order = this.DeserializeObject<OrderModel>(Request.Params["FormJson"]);
            var rowCount = this.OrderBiz.Update拆包(order);

            return Json(new
            {
                Success = rowCount == 1
            });
        }

        public ActionResult ShouHou(Guid id)
        {
            if (!PM.Any(UPM.售后))
            {
                return Redirect("/SignIn");
            }

            var vm = this.OrderBiz.Get售后OrderViewModel(id);
            if (vm.Order == null)
            {
                return Redirect("/Order");
            }

            return View(vm);
        }

        [HttpPost]
        public ActionResult AShouHou()
        {
            if (!PM.Any(UPM.售后))
            {
                return Json(new
                {
                    Success = false
                });
            }

            var order = this.DeserializeObject<OrderModel>(Request.Params["FormJson"]);
            var rowCount = this.OrderBiz.Update售后(order);

            return Json(new
            {
                Success = rowCount == 1
            });
        }

        public ActionResult KeFu(Guid id)
        {
            if (!PM.Any(UPM.客服))
            {
                return Redirect("/SignIn");
            }

            var vm = this.OrderBiz.Get客服OrderViewModel(id);
            if (vm.Order == null)
            {
                return Redirect("/Orders");
            }

            return View(vm);
        }

        [HttpPost]
        public ActionResult AKeFu()
        {
            if (!PM.Any(UPM.客服))
            {
                return Json(new
                {
                    Success = false
                });
            }

            var order = this.DeserializeObject<OrderModel>(Request.Params["FormJson"]);
            var rowCount = this.OrderBiz.Update客服(order);

            return Json(new
            {
                Success = rowCount == 1
            });
        }

        public ActionResult ShouHouList()
        {
            if (!PM.Any(UPM.售后))
            {
                return Redirect("/SignIn");
            }

            var conditions = Request.QueryString.Map<OrderModel>();
            var vm = this.OrderBiz.GetOrderListViewModel(conditions);
            return View(vm);
        }

        public ActionResult KeFuList()
        {
            if (!PM.Any(UPM.客服))
            {
                return Redirect("/SignIn");
            }

            var conditions = Request.QueryString.Map<OrderModel>();
            var vm = this.OrderBiz.GetOrderListViewModel(conditions);
            return View(vm);
        }

        public ActionResult GenJinList()
        {
            var vm = this.OrderBiz.Get跟进ListViewModel();
            vm.Json = SerializeObject(new
            {
                AllIDs = new string[] { },
                currentSortPaging = vm.Orders.GetCurrentSortPaging()
            });
            return View(vm);
        }

        [HttpPost]
        public ActionResult AGenJinList()
        {
            var condition = this.Request.Params.Map<OrderCondition>();
            condition.PageIndex = int.Parse(this.Request.Params["PageIndex"]);

            var list = this.OrderBiz.Get跟进List(condition);
            return this.Json(list);
        }
    }
}