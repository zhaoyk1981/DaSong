using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DaSongERP.WebApp.Controllers
{
    public class StockController : AuthorizedController
    {
        // GET: Stock
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AGetStockInfo()
        {
            var 货号 = Request.Params["货号"] ?? string.Empty;
            var stock = this.StockBiz.Get库存(货号);
            return Json(stock);
        }
    }
}