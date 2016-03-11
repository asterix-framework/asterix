using System;
using Asterix.Framework.WebUi.Browser;

namespace SampleTests.google.Pages
{
    public class Google
    {
        private readonly IWebBrowser _webBrowser;

        private const string ServerAddress = "https://google.com";

        public Google(IWebBrowser webBrowser)
        {
            _webBrowser = webBrowser;
            _webBrowser.ServerAddress = new Uri(ServerAddress);
        }

        public MainPage MainPage { get { return new MainPage(_webBrowser); } }
    }
}
