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
    public class MetaController : AuthorizedController
    {
        public ActionResult ShenDanList()
        {
            if (!PM.Any(UPM.管理))
            {
                return Redirect("/SignIn");
            }

            var vm = this.MetaBiz.Get审单操作ListViewModel();
            vm.Json = SerializeObject(new
            {
                AllIDs = new string[] { },
                currentSortPaging = vm.MetaList.GetCurrentSortPaging()
            });
            return View(vm);
        }

        [HttpPost]
        public ActionResult AShenDanList()
        {
            var condition = this.Request.Params.Map<MetaCondition>();
            condition.PageIndex = int.Parse(this.Request.Params["PageIndex"]);

            var list = this.MetaBiz.Get审单操作List(condition);
            return this.Json(list);
        }

        [HttpPost]
        public ActionResult ADeleteShenDan()
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

            var rowCount = this.MetaBiz.Delete审单操作(id);
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

        public ActionResult NewShenDan()
        {
            var vm = MetaBiz.GetNew审单操作ViewModel();
            return View(vm);
        }

        [HttpPost]
        public ActionResult ACreateShenDan()
        {
            var meta = this.DeserializeObject<MetaModel<Guid>>(Request.Params["FormJson"]);
            var rowCount = this.MetaBiz.Create审单操作(meta);
            return Json(new
            {
                Success = rowCount == 1
            });
        }

        public ActionResult EditShenDan(Guid id)
        {
            var vm = MetaBiz.GetEdit审单操作ViewModel(id);
            return View(vm);
        }

        [HttpPost]
        public ActionResult AUpdateShenDan()
        {
            var meta = this.DeserializeObject<MetaModel<Guid>>(Request.Params["FormJson"]);
            var rowCount = this.MetaBiz.Update审单操作(meta);
            return Json(new
            {
                Success = rowCount == 1
            });
        }


        public ActionResult ShouHouList()
        {
            if (!PM.Any(UPM.管理))
            {
                return Redirect("/SignIn");
            }

            var vm = this.MetaBiz.Get售后操作ListViewModel();
            vm.Json = SerializeObject(new
            {
                AllIDs = new string[] { },
                currentSortPaging = vm.MetaList.GetCurrentSortPaging()
            });
            return View(vm);
        }

        [HttpPost]
        public ActionResult AShouHouList()
        {
            var condition = this.Request.Params.Map<MetaCondition>();
            condition.PageIndex = int.Parse(this.Request.Params["PageIndex"]);

            var list = this.MetaBiz.Get售后操作List(condition);
            return this.Json(list);
        }

        [HttpPost]
        public ActionResult ADeleteShouHou()
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

            var rowCount = this.MetaBiz.Delete售后操作(id);
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

        public ActionResult NewShouHou()
        {
            var vm = MetaBiz.GetNew售后操作ViewModel();
            return View(vm);
        }

        [HttpPost]
        public ActionResult ACreateShouHou()
        {
            var meta = this.DeserializeObject<MetaModel<Guid>>(Request.Params["FormJson"]);
            var rowCount = this.MetaBiz.Create售后操作(meta);
            return Json(new
            {
                Success = rowCount == 1
            });
        }

        public ActionResult EditShouHou(Guid id)
        {
            var vm = MetaBiz.GetEdit售后操作ViewModel(id);
            return View(vm);
        }

        [HttpPost]
        public ActionResult AUpdateShouHou()
        {
            var meta = this.DeserializeObject<MetaModel<Guid>>(Request.Params["FormJson"]);
            var rowCount = this.MetaBiz.Update售后操作(meta);
            return Json(new
            {
                Success = rowCount == 1
            });
        }


        public ActionResult ShouHouReasonList()
        {
            if (!PM.Any(UPM.管理))
            {
                return Redirect("/SignIn");
            }

            var vm = this.MetaBiz.Get售后原因ListViewModel();
            vm.Json = SerializeObject(new
            {
                AllIDs = new string[] { },
                currentSortPaging = vm.MetaList.GetCurrentSortPaging()
            });
            return View(vm);
        }

        [HttpPost]
        public ActionResult AShouHouReasonList()
        {
            var condition = this.Request.Params.Map<MetaCondition>();
            condition.PageIndex = int.Parse(this.Request.Params["PageIndex"]);

            var list = this.MetaBiz.Get售后原因List(condition);
            return this.Json(list);
        }

        [HttpPost]
        public ActionResult ADeleteShouHouReason()
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

            var rowCount = this.MetaBiz.Delete售后原因(id);
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

        public ActionResult NewShouHouReason()
        {
            var vm = MetaBiz.GetNew售后原因ViewModel();
            return View(vm);
        }

        [HttpPost]
        public ActionResult ACreateShouHouReason()
        {
            var meta = this.DeserializeObject<MetaModel<Guid>>(Request.Params["FormJson"]);
            var rowCount = this.MetaBiz.Create售后原因(meta);
            return Json(new
            {
                Success = rowCount == 1
            });
        }

        public ActionResult EditShouHouReason(Guid id)
        {
            var vm = MetaBiz.GetEdit售后原因ViewModel(id);
            return View(vm);
        }

        [HttpPost]
        public ActionResult AUpdateShouHouReason()
        {
            var meta = this.DeserializeObject<MetaModel<Guid>>(Request.Params["FormJson"]);
            var rowCount = this.MetaBiz.Update售后原因(meta);
            return Json(new
            {
                Success = rowCount == 1
            });
        }


        public ActionResult ZhongZhuanCangList()
        {
            if (!PM.Any(UPM.管理))
            {
                return Redirect("/SignIn");
            }

            var vm = this.MetaBiz.Get中转仓ListViewModel();
            vm.Json = SerializeObject(new
            {
                AllIDs = new string[] { },
                currentSortPaging = vm.MetaList.GetCurrentSortPaging()
            });
            return View(vm);
        }

        [HttpPost]
        public ActionResult AZhongZhuanCangList()
        {
            var condition = this.Request.Params.Map<MetaCondition>();
            condition.PageIndex = int.Parse(this.Request.Params["PageIndex"]);

            var list = this.MetaBiz.Get中转仓List(condition);
            return this.Json(list);
        }

        [HttpPost]
        public ActionResult ADeleteZhongZhuanCang()
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

            var rowCount = this.MetaBiz.Delete中转仓(id);
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

        public ActionResult NewZhongZhuanCang()
        {
            var vm = MetaBiz.GetNew中转仓ViewModel();
            return View(vm);
        }

        [HttpPost]
        public ActionResult ACreateZhongZhuanCang()
        {
            var meta = this.DeserializeObject<MetaModel<Guid>>(Request.Params["FormJson"]);
            var rowCount = this.MetaBiz.Create中转仓(meta);
            return Json(new
            {
                Success = rowCount == 1
            });
        }

        public ActionResult EditZhongZhuanCang(Guid id)
        {
            var vm = MetaBiz.GetEdit中转仓ViewModel(id);
            return View(vm);
        }

        [HttpPost]
        public ActionResult AUpdateZhongZhuanCang()
        {
            var meta = this.DeserializeObject<MetaModel<Guid>>(Request.Params["FormJson"]);
            var rowCount = this.MetaBiz.Update中转仓(meta);
            return Json(new
            {
                Success = rowCount == 1
            });
        }



        public ActionResult ShopList()
        {
            if (!PM.Any(UPM.管理))
            {
                return Redirect("/SignIn");
            }

            var vm = this.MetaBiz.Get店铺ListViewModel();
            vm.Json = SerializeObject(new
            {
                AllIDs = new string[] { },
                currentSortPaging = vm.Shops.GetCurrentSortPaging()
            });
            return View(vm);
        }

        [HttpPost]
        public ActionResult AShopList()
        {
            var condition = this.Request.Params.Map<ShopCondition>();
            condition.PageIndex = int.Parse(this.Request.Params["PageIndex"]);

            var list = this.MetaBiz.Get店铺List(condition);
            return this.Json(list);
        }

        [HttpPost]
        public ActionResult ADeleteShop()
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

            var rowCount = this.MetaBiz.Delete店铺(id);
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

        public ActionResult NewShop()
        {
            if (!PM.Any(UPM.管理))
            {
                return Redirect("/SignIn");
            }

            var vm = MetaBiz.GetNewShopViewModel();
            return View(vm);
        }

        [HttpPost]
        public ActionResult ACreateShop()
        {
            var shop = this.DeserializeObject<店铺Model>(Request.Params["FormJson"]);
            var rowCount = this.MetaBiz.Create店铺(shop);
            return Json(new
            {
                Success = rowCount == 1
            });
        }

        public ActionResult EditShop(Guid id)
        {
            if (!PM.Any(UPM.管理))
            {
                return Redirect("/SignIn");
            }

            var vm = MetaBiz.GetEditShopViewModel(id);
            return View(vm);
        }

        [HttpPost]
        public ActionResult AUpdateShop()
        {
            var shop = this.DeserializeObject<店铺Model>(Request.Params["FormJson"]);
            var rowCount = this.MetaBiz.Update店铺(shop);
            return Json(new
            {
                Success = rowCount == 1
            });
        }
    }
}