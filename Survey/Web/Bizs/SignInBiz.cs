using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.ViewModels;

namespace Web.Bizs
{
    public class SignInBiz
    {
        public SignInViewModel GetViewModel()
        {
            var vm = new SignInViewModel();
            return vm;
        }
    }
}