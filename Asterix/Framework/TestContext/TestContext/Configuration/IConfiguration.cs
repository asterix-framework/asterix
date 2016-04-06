using Asterix.Framework.WebUi.Browser;

namespace TestContext.Configuration
{
    public interface IConfiguration
    {
        BrowserType BrowserType { get; }
        string ServerAddress { get; }
    }
}