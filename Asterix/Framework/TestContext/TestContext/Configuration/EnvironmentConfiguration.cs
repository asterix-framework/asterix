using System;
using System.Collections.Generic;
using Asterix.Framework.WebUi.Browser;

namespace TestContext.Configuration
{
    public class EnvironmentConfiguration : IConfiguration
    {
        public BrowserType BrowserType
        {
            get
            {
                string browserType = Environment.GetEnvironmentVariable("BrowserType");

                if (browserType == null)
                {
                    throw new KeyNotFoundException("Environmentkey: BrowserType was not found.");
                }

                return (BrowserType)Enum.Parse(typeof (BrowserType), browserType);
            }
        }

        public string ServerAddress
        {
            get
            {
                string serverAddress = Environment.GetEnvironmentVariable("ServerAddress");

                if (serverAddress == null)
                {
                    throw new KeyNotFoundException("Environmentkey: ServerAddress was not found.");
                }

                return serverAddress;
            }
        }
    }
}
