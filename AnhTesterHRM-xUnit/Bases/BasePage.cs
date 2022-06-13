using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using AnhTesterHRM_xUnit.DriverManage;

namespace AnhTesterHRM_xUnit.Bases
{
    class BasePage
    {
        public static IWebDriver driver;
   

        public void SetupBrowser(string browser)
        {
            driver = BDriverFactory.InitDriver(browser);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1000);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
        }
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
