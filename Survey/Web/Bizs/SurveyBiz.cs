using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.ViewModels;

namespace Web.Bizs
{
    public class SurveyBiz
    {
        public SurveyViewModel GetViewModel()
        {
            var vm = new SurveyViewModel();
            return vm;
        }
    }
}