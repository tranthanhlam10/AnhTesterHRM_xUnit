using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;

namespace AnhTesterHRM_xUnit.Bases
{
    class EmployeePage : BasePage
    {
        //Get locator for role test
        //NOTE: Table must take full xpath
        By roleName = By.XPath("/html/body/div[2]/div/div[4]/div[2]/div/div/div[2]/div/table/tbody/tr/td[2]");

        //Get locator for total row and colunm
        By colPath = By.XPath("/html/body/div[2]/div/div[4]/div[2]/div/div/div[2]/div/table/thead/tr/th"); // total cols always use th
        By rowPath = By.XPath("/html/body/div[2]/div/div[4]/div[2]/div/div/div[2]/div/table/tbody/tr");

        //Get locator for search info Employee by name
        By nameCols = By.XPath("/html/body/div[2]/div/div[4]/div[2]/div/div/div[2]/div/table/tbody/tr/td[3]");
        By rowData = By.XPath("/html/body/div[2]/div/div[4]/div[2]/div/div/div[2]/div/table/tbody/tr");

        //Get locator for search info Employee bay map
        By headerDataRow = By.XPath("/html/body/div[2]/div/div[4]/div[2]/div/div/div[2]/div/table/tbody/tr/th");

        public int FindEmRole()
        {
            driver.Navigate().GoToUrl("https://hrm.anhtester.com/erp/staff-list");
            Thread.Sleep(2000);
            List<IWebElement> roleList = new List<IWebElement>(driver.FindElements(roleName));
            int i = 0;
            foreach (var role in roleList)
            {
                if (String.Compare(role.Text, "Automation") == 0)
                {
                    i++;
                }
            }
            Console.WriteLine("Co tong cong " + i + " Automation Tester trong cong ty");
            return i;
        }


        public int CountTotalRowsAndCols()
        {
            driver.Navigate().GoToUrl("https://hrm.anhtester.com/erp/staff-list");
            Thread.Sleep(2000);
            List<IWebElement> cols = new List<IWebElement>(driver.FindElements(colPath));
            List<IWebElement> rows = new List<IWebElement>(driver.FindElements(rowPath));
            int total = cols.Count + rows.Count;
            return total;
        }

        public bool InputNameOutputInfo(string employee)
        {
            bool isExist = false;
            driver.Navigate().GoToUrl("https://hrm.anhtester.com/erp/staff-list");
            Thread.Sleep(2000);
            List<IWebElement> nameCol = new List<IWebElement>(driver.FindElements(nameCols));
            List<IWebElement> data = new List<IWebElement>(driver.FindElements(rowData));

            for (int i = 0; i < nameCol.Count; i++)
            {
                if (nameCol[i].Text == employee)
                {
                    Console.WriteLine(data[i].Text.ToString());
                    return true;
                }
            }
            return isExist;
        }

        public bool InputInfoOutPutInfo(string info)
        {
            bool expected = true;
            driver.Navigate().GoToUrl("https://hrm.anhtester.com/erp/staff-list");
            //List type SortedList to stored all cell data after funciton closed !
            List<SortedList<string, string>> cellTableData = new List<SortedList<string, string>>();
            //List to get headerdata
            /// html / body / div[2] / div / div[4] / div[2] / div / div / div[2] / div / table / tbody / tr / th
            List<IWebElement> headerData = new List<IWebElement>(driver.FindElements(headerDataRow));
            //List to stored headerdata
            Thread.Sleep(20);
            List<string> saveHeaderData = new List<string>();
            //A loop to add header data to list 3
            foreach (IWebElement loop in headerData)
            {
                string data = loop.Text;
                saveHeaderData.Add(data);
            }
            Thread.Sleep(20);
            //List to get data from rows
            /// html / body / div[2] / div / div[4] / div[2] / div / div / div[2] / div / table / tbody / tr
            /// //*[@id="xin_table"]/tbody/tr[6]/td[1]
            List<IWebElement> rowsData = new List<IWebElement>(driver.FindElements(By.XPath("//*[@id=\"xin_table\"]/tbody/tr[6]/td[1]")));
            for (int i = 2; i < rowsData.Count; i++)
            {
                //List to get cell data
                //List<IWebElement> cellDataByRow = new List<IWebElement>(driver.FindElements(By.XPath("html/body/div[2]/div/div[4]/div[2]/div/div/div[2]/div/table/tbody/tr["+i+"]/td")));
                List<IWebElement> cellDataByRow = new List<IWebElement>(driver.FindElements(By.XPath("//*[@id=\"xin_table\"]/tbody/tr[" + i + "]/td")));
                //Stored List to save cell data
                SortedList<string, string> saveCellData = new SortedList<string, string>();
                //A loop to put header and cell data to cellTableData 
                for (int j = 0; j < cellDataByRow.Count; j++)
                {
                    string celldata = cellDataByRow[j].Text;
                    saveCellData.Add(saveHeaderData[j], celldata);
                }
                cellTableData.Add(saveCellData);
            }

            // A loop to find employee in List<StoredList>
            foreach (SortedList<string, string> save in cellTableData)
            {
                List<string> value = new List<string>(save.Values);
                foreach (string celldata in value)
                {
                    if (celldata.Contains(info))
                    {
                        return expected = true;
                    }
                    else
                        return expected = false;
                }
            }
            return expected;
        }
    }
}
