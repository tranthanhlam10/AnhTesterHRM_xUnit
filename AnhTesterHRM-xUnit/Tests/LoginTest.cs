using AnhTesterHRM_xUnit.Bases;
using AnhTesterHRM_xUnit.Utils;
using System;
using Xunit;

namespace AnhTesterHRM_xUnit.Tests
{
    public class LoginTest : BaseTest , IDisposable
    {
        LoginPage loginPage = new LoginPage();
        static ExcelReader excelReader = new ExcelReader("C:/Thanh Lam Tran/CsharpExcelReader.xlsx", "Sheet1");


        [Theory]
        [InlineData("employee01", "123456")]
        [InlineData("leader01", "123456")]
        [InlineData("admin01", "123456")]
        [InlineData("client01", "123456")]
        public void LoginTestBasic(string userName, string passWord)
        {
            Assert.Equal("https://hrm.anhtester.com/erp/desk", loginPage.Login(userName, passWord));
        }

  
        [Fact , Trait("Category", "LogutBasic")]
        public void LogoutTest()
        {
            loginPage.Login("admin01", "123456");
            Assert.NotEqual("Cant not logout this page", loginPage.Logout());
        }


        [Fact , Trait("Category","Login")]
        public void LoginTestExcelFile()
        {
            Assert.Equal("https://hrm.anhtester.com/erp/desk", loginPage.Login(excelReader.GetCellData(1), excelReader.GetCellData(2)));
        }
    }
}
