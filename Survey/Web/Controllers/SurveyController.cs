using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Bizs;

namespace Web.Controllers
{
    public class SurveyController : DefaultController
    {
        private SurveyBiz SurveyBiz { get; set; } = new SurveyBiz();
        // GET: Default
        public ActionResult Index()
        {
            var vm = this.SurveyBiz.GetViewModel();
            return View(vm);
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult SaveSurvey()
        {
            //var user = Newtonsoft.Json.JsonConvert.DeserializeObject<UserModel>(Request.Params["ModelJson"]);
            return Json(new { });
        }
    }
}