using AnhTesterHRM_xUnit.Bases;
using AnhTesterHRM_xUnit.Utils;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading;

namespace AnhTesterHRM_xUnit.Tests
{
    public class BaseTest : IDisposable
    {
        BasePage basePage = new BasePage();
        ConfigSetting config = new ConfigSetting();


        public BaseTest()
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile("C:/Specflow/AnhTesterHRM-xUnit/AnhTesterHRM-xUnit/Utils/ConfigEnv.json");
            IConfigurationRoot configuration = builder.Build();
            configuration.Bind(config);
            Thread.Sleep(1000);
            basePage.SetupBrowser(config.env); // change env and env2 to switch browser. .
        }

        public void Dispose()
        {
            basePage.TearDown();
        }

    }
}
