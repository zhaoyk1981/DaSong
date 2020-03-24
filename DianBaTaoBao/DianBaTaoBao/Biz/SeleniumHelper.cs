using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DianBaTaoBao.Biz
{
    public class SeleniumHelper
    {
        private IWebDriver _WebDriver;
        public IWebDriver WebDriver
        {
            get
            {
                if (this._WebDriver == null)
                {
                    if (!Directory.Exists("c:\\ffehe"))
                    {
                        Directory.CreateDirectory("c:\\ffehe");
                    }

                    OpenQA.Selenium.Firefox.FirefoxDriverService driverService = OpenQA.Selenium.Firefox.FirefoxDriverService.CreateDefaultService();
                    driverService.HideCommandPromptWindow = true;//关闭cmd窗口
                    var options = new OpenQA.Selenium.Firefox.FirefoxOptions();

                    //options.AddArgument("--headless");
                    //options.AddArgument("--disable-gpu");
                    options.Profile = new OpenQA.Selenium.Firefox.FirefoxProfile("c:\\ffehe", false);
                    options.Profile.SetPreference("browser.cache.disk.parent_directory", "C:\\ffehecache");
                    this._WebDriver = new OpenQA.Selenium.Firefox.FirefoxDriver(driverService, options);
                    //this._WebDriver.Manage().Window.Maximize();
                }

                return this._WebDriver;
            }
            set
            {
                this._WebDriver = value;
            }
        }

        public bool RedirectTo(string url)
        {
            var retry = 10;
            while (true)
            {
                //var exp = DateTime.Now.AddSeconds(120);
                try
                {
                    if (this.WebDriver.Url == url)
                    {
                        this.WebDriver.Navigate().Refresh();
                    }
                    else
                    {
                        this.WebDriver.Navigate().GoToUrl(url);
                    }

                    new WebDriverWait(this.WebDriver, new TimeSpan(0, 4, 0)).Until(
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

                    if (this.WebDriver.Url == url)
                    {
                        return true;
                    }
                    retry--;
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

        public virtual void Sleep(double seconds)
        {
            System.Threading.Thread.Sleep(Convert.ToInt32(seconds * 1000));
        }

        public void QuitDriver()
        {
            if (this.WebDriver == null)
            {
                return;
            }

            try
            {
                this.WebDriver.Quit();
                this.WebDriver.Dispose();
            }
            catch
            {

            }
            finally
            {
                this.WebDriver = null;
            }
        }

        public IWebElement FindWebElement(string cssSelector)
        {
            var retry = 5;
            while (retry > 0)
            {
                var list = this.WebDriver.FindElements(By.CssSelector(cssSelector)).ToList();
                foreach (var ctrl in list)
                {
                    if (ctrl.Displayed)
                    {
                        return ctrl;
                    }
                }

                retry--;
                this.Sleep(0.1);
            }

            return null;
        }

        public IWebElement FindWebElement(IWebElement webElement, string cssSelector)
        {
            var retry = 5;
            while (retry > 0)
            {
                var list = webElement.FindElements(By.CssSelector(cssSelector)).ToList();
                foreach (var ctrl in list)
                {
                    if (ctrl.Displayed)
                    {
                        return ctrl;
                    }
                }

                retry--;
                this.Sleep(0.1);
            }

            return null;
        }

        public IList<IWebElement> FindWebElements(string cssSelector)
        {
            var retry = 5;
            while (retry > 0)
            {
                var list = this.WebDriver.FindElements(By.CssSelector(cssSelector)).Where(m => m.Displayed).ToList();
                if (list.Count > 0)
                {
                    return list;
                }

                this.Sleep(0.1);
            }

            return null;
        }

        public void WaitWebElementHide(string cssSelector)
        {
            while (true)
            {
                var element = FindWebElement(cssSelector);
                if (element == null)
                {
                    break;
                }

                if (!element.Displayed)
                {
                    break;
                }

                this.Sleep(0.1);
            }
        }
    }
}
