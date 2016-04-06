using System;
using System.Configuration;
using Asterix.Framework.WebUi.Browser;

namespace TestContext.Configuration
{
    public class ConfigFileConfiguration : IConfiguration
    {
        private readonly System.Configuration.Configuration _configuration;

        public ConfigFileConfiguration(string filePath)
        {
            _configuration = ConfigurationManager.OpenExeConfiguration(filePath);
        }

        public BrowserType BrowserType
        {
            get
            {
                KeyValueConfigurationElement browserType = _configuration.AppSettings.Settings["BrowserType"];
                return (BrowserType)Enum.Parse(typeof(BrowserType), browserType.Value);
            } 
        }

        public string ServerAddress
        {
            get
            {
                KeyValueConfigurationElement serverAddress = _configuration.AppSettings.Settings["ServerAddress"];
                return serverAddress.Value;
            }
        }
    }
}
