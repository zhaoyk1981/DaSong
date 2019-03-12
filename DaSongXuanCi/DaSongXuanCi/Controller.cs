using DaSongXuanCi.Models;
using DaSongXuanCi.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaSongXuanCi
{
    public class Controller
    {
        public Controller(ViewModel model)
        {
            this.Model = model;
        }

        private ViewModel Model { get; set; }

        public void 开始操作()
        {
            var loginPage = new 登录页(this.Model, new 帐户Model()
            {
                用户名 = "琪可朵企业店:运营1",
                密码 = "hui123456"
            });
            loginPage.跳转();
            if (!loginPage.登录())
            {
                return;
            }


        }
    }
}
