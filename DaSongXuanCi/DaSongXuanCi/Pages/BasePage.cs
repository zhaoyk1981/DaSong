using DaSongXuanCi.Models;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaSongXuanCi.Pages
{
    public class BasePage
    {
        public BasePage(ViewModel model, 帐户Model account)
        {
            this.Model = model;
            this.帐户 = account;
        }

        protected virtual ViewModel Model { get; set; }

        protected virtual 帐户Model 帐户 { get; set; }

        public bool 已输入验证码 { get; set; }

        public virtual void Sleep(double seconds)
        {
            System.Threading.Thread.Sleep(Convert.ToInt32(seconds * 1000));
        }

        public virtual T ConvertJson<T>(string str)
        {
            return JsonConvert.DeserializeObject<T>(str);
        }


        protected virtual bool 跳转(string url)
        {
            var retry = 10;
            while (true)
            {
                var exp = DateTime.Now.AddSeconds(120);
                try
                {
                    if (this.Model.WebDriver.Url == url)
                    {
                        this.Model.WebDriver.Navigate().Refresh();
                    }
                    else
                    {
                        // 跳转到登录页
                        this.Model.WebDriver.Navigate().GoToUrl(url);
                    }

                    this.等待页面加载完成(4);

                    while (this.Model.WebDriver.Url != url)
                    {

                        if (DateTime.Now > exp)
                        {
                            break;
                        }
                        this.Sleep(0.1);
                    }

                    if (this.Model.WebDriver.Url == url)
                    {
                        return true;
                    }

                    retry--;
                    if (retry <= 0)
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    retry--;
                    if (retry <= 0)
                    {
                        throw ex;
                    }

                }

                this.Sleep(3);
            }
        }

        protected void 等待页面加载完成(int minutes)
        {
            new WebDriverWait(this.Model.WebDriver, new TimeSpan(0, minutes, 0)).Until(
                        d =>
                        {
                            var isComplete = false;
                            try
                            {
                                isComplete = ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").ToString() == "complete";
                                return isComplete;
                            }
                            catch
                            {
                            }

                            return isComplete;
                        });
        }

        protected virtual bool 对比预期值(decimal val, 预期值 预期值)
        {
            switch (预期值)
            {
                case 预期值.等于0:
                    {
                        return val == 0m;
                    }
                case 预期值.大于等于1:
                    {
                        return val >= 1m;
                    }
                case 预期值.大于0:
                    {
                        return val > 0;
                    }
                case 预期值.小于1:
                    {
                        return val < 1;
                    }
            }

            return false;
        }

        public void 报告进度(UserStateModel userState)
        {
            this.Model.Worker.ReportProgress(0, userState);
        }
    }
}
