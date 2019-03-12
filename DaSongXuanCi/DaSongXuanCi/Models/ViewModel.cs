using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaSongXuanCi.Models
{
    public class ViewModel
    {
        private IWebDriver _WebDriver;

        public IWebDriver WebDriver
        {
            get
            {
                if (this._WebDriver == null)
                {
                    if (!Directory.Exists("c:\\ffp_DaSongXuanCi"))
                    {
                        Directory.CreateDirectory("c:\\ffp_DaSongXuanCi");
                    }

                    OpenQA.Selenium.Firefox.FirefoxDriverService driverService = OpenQA.Selenium.Firefox.FirefoxDriverService.CreateDefaultService();

                    driverService.HideCommandPromptWindow = true;//关闭cmd窗口

                    var options = new OpenQA.Selenium.Firefox.FirefoxOptions();

                    options.Profile = new OpenQA.Selenium.Firefox.FirefoxProfile("c:\\ffp_DaSongXuanCi", false);
                    options.Profile.SetPreference("browser.cache.disk.parent_directory", "C:\\ffc_DaSongXuanCi");
                    this._WebDriver = new OpenQA.Selenium.Firefox.FirefoxDriver(driverService, options);
                    this._WebDriver.Manage().Window.Maximize();
                }

                return this._WebDriver;
            }
            set
            {
                this._WebDriver = value;
            }
        }

        public bool 零售模式 => false;

        public BackgroundWorker Worker { get; set; } = new BackgroundWorker()
        {
            WorkerSupportsCancellation = true,
            WorkerReportsProgress = true
        };

        public string 激活码 { get; set; }

        public bool? 手动登录 { get; set; }

        public 操作 当前操作 { get; set; }
    }
}
