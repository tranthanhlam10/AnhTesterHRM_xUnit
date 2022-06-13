using AnhTesterHRM_xUnit.Bases;
using System;
using Xunit;

namespace AnhTesterHRM_xUnit.Tests
{
    public class EmployeeTest : BaseTest, IDisposable
    {
        LoginPage loginPage = new LoginPage();
        EmployeePage employeePage = new EmployeePage();

    
        public EmployeeTest()
        {
            loginPage.Login("admin01", "123456");
        }

        //Pass
        [Fact]
        public void testRoleNameOnEmTable()
        {
            Assert.Equal(2, employeePage.CountEmployeeByRole());
        }

        //Pass
        [Fact]
        public void testCountTotalColsAndRow()
        {
            Assert.Equal(15, employeePage.CountTotalRowsAndCols());
        }

        //Pass
        [Fact]
        public void testFindNameOuputInfo()
        {
            Assert.False(employeePage.InputNameOutputInfo("1234567555"));
        }

        [Fact]
        public void testFindNameOuputInfoByList()
        {
            Assert.True(employeePage.InputInfoOutPutInfo("012345"));
        }
    }
}
