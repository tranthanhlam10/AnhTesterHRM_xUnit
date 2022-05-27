using OpenQA.Selenium;
using System.Threading;


namespace AnhTesterHRM_xUnit.Bases
{
    class LoginPage :BasePage
    {
        // Get locator for Login testing
        By txtUserName = By.XPath("//input[@id='iusername']");
        By txtPassWord = By.XPath("//input[@id='ipassword']");
        By btnLogin = By.XPath("//span[@class='ladda-label']");

        // Get loactor for Logout testing
        By btnLogout = By.XPath("/html/body/div[2]/div/div[1]/div/div/div[2]/a");

        public string Login(string userName, string passWord)
        {
            driver.Navigate().GoToUrl("https://hrm.anhtester.com/");
            driver.FindElement(txtUserName).SendKeys(userName);
            driver.FindElement(txtPassWord).SendKeys(passWord);
            driver.FindElement(btnLogin).Click();

            Thread.Sleep(5000);
            // this url need timeout to load new url
            return driver.Url;
        }

        public string Logout() // phai dang nhap truoc moi duoc
        {
            ;
            if (driver.FindElement(btnLogout).Displayed)
            {
                driver.FindElement(btnLogout).Click();
                Thread.Sleep(2000);
                return driver.Url;
            }
            else
                return "Cant logout this page";
        }

    }
}
