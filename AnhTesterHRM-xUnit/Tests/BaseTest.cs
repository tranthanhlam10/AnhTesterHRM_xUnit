using AnhTesterHRM_xUnit.Bases;
using AnhTesterHRM_xUnit.Utils;
using Microsoft.Extensions.Configuration;
using System;   

namespace AnhTesterHRM_xUnit.Tests
{
    public class BaseTest : IDisposable
    {
        BasePage basePage = new BasePage();
        ConfigSetting config = new ConfigSetting();

        public string ReadJson()
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile("Utils/ConfigEnv.json");
            IConfigurationRoot configuration = builder.Build();
            configuration.Bind(config);
            return config.env;
        }

        public BaseTest()
        {
           
            basePage.SetupBrowser(ReadJson());
        }

        public void Dispose()
        {
            basePage.TearDown();
        }

    }
}
