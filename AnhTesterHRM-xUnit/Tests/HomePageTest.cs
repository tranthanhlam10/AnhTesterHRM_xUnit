using AnhTesterHRM_xUnit.Bases;
using System;
using Xunit;

namespace AnhTesterHRM_xUnit.Tests
{
    public class HomePageTest : BaseTest, IDisposable
    {
        HomePage homePage = new HomePage();
        LoginPage loginPage = new LoginPage();

       
        public HomePageTest()
        {
            loginPage.Login("admin01", "123456");
        }

        //Pass
        [Fact]
        public void CheckHomeValueTest()
        {
            Assert.True(homePage.CheckHomepageInfor("₫0.00", "0", "0", "0"));
        }

        //Pass
        [Fact]
        public void CheckLeftBar()
        {
            Assert.Equal(5, homePage.CheckLeftBarClick());
        }

        //Fail, bug on Xpath
        [Fact]
        public void CheckDropDown()
        {
            Assert.Equal("https://hrm.anhtester.com/erp/leave-list", homePage.CheckDropDown());
        }

        //Pass
        [Fact]
        public void CheckHomeDropDownBtn()
        {
            Assert.NotNull(homePage.CheckDropDownMenu());
        }


        [Fact]
        public void CheckViewDetailProject()
        {
            Assert.Same("View project detail successfully", homePage.CheckViewProjectDetail());
        }


        [Fact]
        public void CheckDeleteProject()
        {
            Assert.False(homePage.CheckDeleteProject());
        }
    }
}
