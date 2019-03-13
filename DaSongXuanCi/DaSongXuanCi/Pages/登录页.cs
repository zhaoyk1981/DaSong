using DaSongXuanCi.Models;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaSongXuanCi.Pages
{
    public class 登录页 : BasePage
    {
        public 登录页(ViewModel model, 帐户Model account) : base(model, account)
        {

        }

        public const string URL = "https://sycm.taobao.com/custom/login.htm";

        public const string HOME_URL = "https://sycm.taobao.com/portal/home.htm";

        public bool 跳转()
        {
            var result = this.跳转(URL);
            return result;
        }

        public bool 登录()
        {
            while (true)
            {
                if (this.Model.Worker.CancellationPending)
                {
                    return false;
                }

                
                // 输入登录信息
                
                //if (!string.IsNullOrEmpty(this.帐户.用户名))
                //{
                //    this.Model.WebDriver.SwitchTo().Frame(0);
                //    var c = this.Controls;
                //    c["txtUserName"].Clear();
                //    c["txtUserName"].SendKeys(this.帐户.用户名);

                //    c["txtPassword"].Clear();
                //    c["txtPassword"].SendKeys(this.帐户.密码);
                //    this.Sleep(1);
                //    if (this.Model.WebDriver.FindElements(By.CssSelector("#nocaptcha")).SingleOrDefault() == null)
                //    {
                //        c["btnLoginSubmit"].Click();
                //    }
                //}

                this.Model.WebDriver.SwitchTo().DefaultContent();
                //this.Sleep(1);

                // 等待登录完成
                this.等待页面加载完成(4);
                while (true)
                {
                    this.报告进度(new UserStateModel() { 需要手动登录 = true });
                    while (true)
                    {
                        if (this.Model.Worker.CancellationPending)
                        {
                            return false;
                        }

                        if (this.Model.手动登录.HasValue)
                        {
                            if (this.Model.手动登录.Value)
                            {
                                break;
                            }
                            else
                            {
                                return false;
                            }
                        }

                        this.Sleep(0.1);
                    }

                    if (this.Model.WebDriver.Url == HOME_URL)
                    {
                        break;
                    }
                }

                //while (this.Model.WebDriver.Url == URL)
                //{
                //    // 检测是否需要验证码
                //    var txtSecuret = this.Model.WebDriver.FindElements(By.CssSelector("input[ng-model=\"imageParam.secret\"]")).SingleOrDefault();
                //    if ((txtSecuret?.Displayed).GetValueOrDefault())
                //    {

                //        this.Model.Worker.ReportProgress(0, new UserStateModel($"登录需要验证码，请手动登录后点击\"继续\"按钮。{this.帐户.别名}") { 需要登录验证码 = true });
                //        while (!this.Model.已手动登录)
                //        {
                //            this.Sleep(0.5);
                //        }

                //        return true;
                //    }

                //    this.Sleep(0.1);
                //}

                //this.Sleep(4);
                //return this.Model.WebDriver.Url == HOME_URL;
                return true;
            }
        }

        private Dictionary<string, IWebElement> _Controls;

        private Dictionary<string, IWebElement> Controls
        {
            get
            {
                if (this._Controls == null)
                {
                    this._Controls = this.GetControls();
                }

                return this._Controls;
            }
            set
            {
                this._Controls = value;
            }
        }

        private Dictionary<string, IWebElement> GetControls(int timeout = 30)
        {
            var exp = DateTime.Now.AddSeconds(timeout);
            var list = new Dictionary<string, IWebElement>();
            while (true)
            {
                try
                {
                    var txtUserName = this.Model.WebDriver.FindElements(By.CssSelector("#TPL_username_1")).SingleOrDefault();
                    if (txtUserName != null)
                    {
                        list.Add("txtUserName", txtUserName);
                        break;
                    }
                }
                catch
                {

                }
                this.Sleep(0.1);
            }

            while (true)
            {
                try
                {
                    var txtPassword = this.Model.WebDriver.FindElements(By.CssSelector("#TPL_password_1")).SingleOrDefault();
                    if (txtPassword != null)
                    {
                        list.Add("txtPassword", txtPassword);
                        break;
                    }
                }
                catch { }
                this.Sleep(0.1);
            }

            while (true)
            {
                try
                {
                    var btnLoginSubmit = this.Model.WebDriver.FindElements(By.CssSelector("#J_SubmitStatic")).SingleOrDefault();
                    if (btnLoginSubmit != null)
                    {
                        list.Add("btnLoginSubmit", btnLoginSubmit);
                        break;
                    }
                }
                catch { }
                this.Sleep(0.1);
            }

            return list;
        }
    }
}
