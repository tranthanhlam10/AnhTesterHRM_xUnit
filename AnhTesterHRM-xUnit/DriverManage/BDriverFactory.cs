using OpenQA.Selenium;
using System.Collections.Generic;

namespace AnhTesterHRM_xUnit.DriverManage
{
    public class BDriverFactory
    {
        private static Dictionary<string, BDriverManager> _drivers;

        public static IWebDriver InitDriver(string browser)
        {
            _drivers = new Dictionary<string, BDriverManager>();
            _drivers.Add("chrome", new ChromeDriverManager());
            _drivers.Add("edge", new EdgeDriverManager());

            BDriverManager bDriverManager = _drivers[browser];
            return bDriverManager.GetDriver();
        }
    }
}
