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
    public class StockController : AuthorizedController
    {
        public ActionResult Index()
        {
            var vm = this.库存商品Biz.Get库存商品ListViewModel();
            vm.Json = SerializeObject(new
            {
                AllIDs = new string[] { },
                currentSortPaging = vm.ModelList.GetCurrentSortPaging()
            });
            return View(vm);
        }

        [HttpPost]
        public ActionResult AIndex()
        {
            var condition = this.Request.Params.Map<库存商品Condition>();
            condition.PageIndex = int.Parse(this.Request.Params["PageIndex"]);

            var list = this.库存商品Biz.Get库存商品List(condition);
            return this.Json(list);
        }

        [HttpPost]
        public ActionResult ADelete()
        {
            Guid id;
            if (!Guid.TryParse(Request.Params["id"], out id))
            {
                return Json(new
                {
                    Success = false,
                    ErrorMessage = string.Empty
                });
            }

            var rowCount = this.库存商品Biz.Delete库存商品(id);
            if (rowCount == 0)
            {
                return Json(new
                {
                    Success = false
                });
            }

            return Json(new
            {
                Success = true
            });
        }

        public ActionResult New()
        {
            var vm = 库存商品Biz.GetNew库存商品ViewModel();
            return View(vm);
        }

        [HttpPost]
        public ActionResult ACreate()
        {
            var model = this.DeserializeObject<库存商品Model>(Request.Params["FormJson"]);
            var rowCount = this.库存商品Biz.Create库存商品(model);
            return Json(new
            {
                Success = rowCount == 1
            });
        }

        public ActionResult Edit(Guid id)
        {
            var vm = 库存商品Biz.GetEdit库存商品ViewModel(id);
            return View(vm);
        }

        [HttpPost]
        public ActionResult AUpdate()
        {
            var model = this.DeserializeObject<库存商品Model>(Request.Params["FormJson"]);
            var rowCount = this.库存商品Biz.Update库存商品(model);
            return Json(new
            {
                Success = rowCount == 1
            });
        }

        [HttpPost]
        public ActionResult AGetSpecOptions()
        {
            var condition = this.DeserializeObject<库存商品Condition>(Request.Params["FormJson"]);
            var options = this.库存商品Biz.Get规格Options(condition);

            return Json(new
            {
                SpecOptions = options
            });
        }
    }
}