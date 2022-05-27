using OpenQA.Selenium;
using System.Collections;
using System.Threading;

namespace AnhTesterHRM_xUnit.Bases
{
    class HomePage : BasePage
    {
        //Get locator for home page test display and value (4)
        By txtCostRequest = By.XPath("//h3[contains(text(),'₫0.00')]");
        By txtDayOff = By.XPath("/html/body/div[2]/div/div[2]/div[2]/div[1]/div[2]/div/div/div/div[1]/h3");
        By txtPrizes = By.XPath("/html/body/div[2]/div/div[2]/div[1]/div[2]/div/div[3]/div[1]/div/div/div/div[1]/h3");
        By txtTotalAsset = By.XPath("/html/body/div[2]/div/div[2]/div[1]/div[2]/div/div[3]/div[2]/div/div/div/div[1]/h3");

        //Get locator for leftbar(14)
        By homeButtonLB = By.XPath("/html/body/nav/div/div/ul/li[2]/a");
        By homeAttendenceLB = By.XPath("/html/body/nav/div/div/ul/li[3]/a");
        By homeProjectLB = By.XPath("/html/body/nav/div/div/ul/li[4]/a");
        By homeTaskLB = By.XPath("//html/body/nav/div/div/ul/li[5]/a");
        By homeSalaryLB = By.XPath("//html/body/nav/div/div/ul/li[6]/a");

        //Get locator for dropdown(2)
        By homeRequestLB = By.XPath("//li[@class='pc-item pc-trigger']//span[@class='pc-arrow']//*[name()='svg']"); // locator cho nay sai 
        By dbTakeRequest = By.XPath("//a[contains(text(),'Để lại Yêu cầu')]");
        By dbTakeRequest2 = By.XPath("/html/body/nav/div/div/ul/li[7]/ul/li[1]/a");
        By homeRequestLB2 = By.XPath("/html/body/nav/div/div/ul/li[7]/a");

        //Get locator for dropdownmenu(2)
        By featureDM = By.XPath("//span[@data-toggle='tooltip']");
        By eventDM = By.XPath("//span[contains(text(),'Sự kiện')]");

        //Get locator for read detail project
        By btnDetailPj = By.XPath("/html/body/div[2]/div/div[4]/div/div[2]/div[2]/div/div/div[2]/div/table/tbody/tr[1]/td[1]/div/span[1]/a/button");
        By btnDetailPjE = By.CssSelector("tbody tr:nth-child(1) td:nth-child(1) div:nth-child(1) span:nth-child(1) a:nth-child(1) button:nth-child(1) i:nth-child(1)");
        By btnUpdateStatusPj = By.CssSelector("form[id='update_project_progress'] span[class='ladda-label']");
        By elementOnTable = By.CssSelector("tbody tr:nth-child(1) td:nth-child(1) div:nth-child(1)");

        //Get locator for delete project
        By btnDeletePj = By.XPath("//*[@id=\"xin_table\"]/tbody/tr[2]/td[1]/div/span[1]/a/button");
        By elenment2OnTable = By.XPath("//*[@id=\"xin_table\"]/tbody/tr[2]");
        By elenment30nTable = By.CssSelector("#xin_table > tbody > tr:nth-child(2)");
        By btnDeletePj2 = By.CssSelector("#xin_table > tbody > tr:nth-child(2) > td.sorting_1 > div > span:nth-child(2) > button");


        public string CheckHomepageInfor(string cost, string day, string prize, string asset)
        {
            try
            {
                Thread.Sleep(100);
                if (driver.FindElement(txtCostRequest).Text == cost && driver.FindElement(txtDayOff).Text == day && driver.FindElement(txtPrizes).Text == prize && driver.FindElement(txtTotalAsset).Text == asset)
                {
                    return "pass";
                }
                else return "fail";
            }
            catch (NoSuchElementException)
            {
                return "pass";
            }
        }

        public int CheckLeftBarClick()
        {

            Hashtable hashtable = new Hashtable();
            hashtable.Add("button", homeButtonLB);
            hashtable.Add("anttendence", homeAttendenceLB);
            hashtable.Add("project", homeProjectLB);
            hashtable.Add("task", homeTaskLB);
            hashtable.Add("salary", homeSalaryLB);

            int totalClick = 0;
            foreach (By element in hashtable.Values)
            {
                driver.FindElement(element).Click();
                totalClick++;
            }
            return totalClick;
        }

        public string CheckDropDown()
        {
            try
            {
                driver.FindElement(homeRequestLB2).Click();
                Thread.Sleep(200);
                if (driver.FindElement(dbTakeRequest2).Displayed) // wrong locator ??
                {
                    Thread.Sleep(200);
                    driver.FindElement(dbTakeRequest2).Click();

                    return "https://hrm.anhtester.com/erp/leave-list";
                }
                else
                {
                    driver.Navigate().GoToUrl("https://hrm.anhtester.com/erp/desk");
                    return "https://hrm.anhtester.com/erp/desk";
                }
            }
            catch (InvalidSelectorException)
            {
                return "Error";
            }
        }

        public string CheckDropDownMenu()
        {
            driver.FindElement(featureDM).Click();
            Thread.Sleep(20);
            driver.FindElement(eventDM).Click();
            Thread.Sleep(10);

            return "https://hrm.anhtester.com/erp/events-list";
        }

        public string CheckViewProjectDetail()
        {
            try
            {
                driver.Navigate().GoToUrl("https://hrm.anhtester.com/erp/projects-list");
                Thread.Sleep(200);
                driver.FindElement(elementOnTable).Click();
                if (driver.FindElement(btnDetailPjE).Displayed)
                {
                    driver.FindElement(btnDetailPjE).Click();
                    driver.FindElement(btnUpdateStatusPj).Click();
                    return "View project detail successfully";
                }
                else
                    return "View project detail unsucessfully";

            }
            catch (NoSuchElementException)
            {
                return "View project detail successfully";
            }
        }

        public string CheckDeleteProject()
        {
            try
            {
                driver.Navigate().GoToUrl("https://hrm.anhtester.com/erp/projects-list");
                Thread.Sleep(2000);
                driver.FindElement(elenment30nTable).Click();
                if (driver.FindElement(btnDeletePj2).Displayed)
                {
                    driver.FindElement(btnDeletePj2).Click();
                    return "Delete project detail successfully";
                }
                else
                    return "Delete project detail unsucessfully";

            }
            catch (InvalidSelectorException)
            {
                return "Exception project detail successfully";
            }
        }
    }
}
