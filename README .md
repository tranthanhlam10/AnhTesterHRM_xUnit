
# Selenium C# - Anh Tester HRM System

This is a test project written in C# programming language, with Selenium framework and xUnit library.

## Programming tools and libraries

- Visual Studio 2022
- .Net 6.0
- Selenium
- Webdriver Manager
- xUnit
- Browser Driver
- Microsoft.Extensions.Configuration.Binder
- Microsoft.Extensions.Configuration.Json
- Microsoft.NET.Test.Sdk
- EPPlus
- EPPlus.System.Drawing
 *Install on Nuget package*

## Main test case

### Login
- Login basic: Add username and password to function and test.
- Login with data provider: Add more data about username and password.
- Login witd data from excel file: Add data to test function by ExcelReader.
### HomePage
- Test UI from HomePage
### EmployeePage
- Test HTML table by Selenium C#: find data, total cells, use collections to handle HTML table.

## Run test

- Open commandline and type "dotnet test" to run all test.
- Open commandline and type "dotnet test --filter "TestCategory=tagname" to run all test.
* @Trait("Category", "Category") is defined before each test case*.
*you also define same @Trait to group more test cases you wanna run*

### Step to change Browser
1. Open Config.Json.
2. Chang value of env, if you want to use Edge Browser, change "chrome" to "edge".


