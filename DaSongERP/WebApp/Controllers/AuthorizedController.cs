using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DaSongERP.WebApp.Controllers
{
    public class AuthorizedController : BaseController
    {
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            if (LoggedAccount == null)
            {
                filterContext.Result = RedirectToAction("index", "SignIn");
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //var permissionId = this.LoggedAccount?.PermissionId.GetValueOrDefault();
            //var permissionDict = this.GetPermissionsClass();
            //var permissionClass = String.Join(" ", String.Join(" ", permissionDict
            //    .Where(m => ((int)permissionId & m.Key) == m.Key)
            //    .Select(m => m.Value).ToArray())
            //    .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            //    .Distinct());
            //ViewData["PermissionClass"] = permissionClass;
            base.OnActionExecuting(filterContext);
        }

        private IDictionary<int, string> GetPermissionsClass()
        {
            var dict = new Dictionary<int, string>();
            dict.Add(1, "admin");
            dict.Add(2, "contributor");
            dict.Add(4, "reviewers");
            dict.Add(8, "reviewers");
            dict.Add(16, "download-manuscripts");
            dict.Add(32, "screen");
            dict.Add(64, "reviewers");
            dict.Add(128, "reviewers sensitive-words-reviewers");
            dict.Add(256, "theme-planning");
            dict.Add(512, "news");
            dict.Add(1024, "public-optinion");
            dict.Add(2048, "public-optinion-view");
            dict.Add(4096, "dept-media");
            dict.Add(8192, "my-media-lib");
            dict.Add(16384, "review-media");
            dict.Add(32768, "review-media");
            dict.Add(65536, "media-admin");
            dict.Add(131072, "media-lib");
            dict.Add(262144, "download-manuscripts download-all-manuscripts");
            dict.Add(524288, "submit-contributor");
            dict.Add(1048576, "submit-download");
            dict.Add(2097152, "submit-reviewers");
            dict.Add(4194304, "submit-reviewers");
            dict.Add(8388608, "submit-reviewers");
            return dict;
        }
    }
}