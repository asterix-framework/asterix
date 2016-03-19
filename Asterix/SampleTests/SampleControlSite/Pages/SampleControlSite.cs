using System;
using Asterix.Framework.WebUi.Browser;

namespace SampleTests.SampleControlSite.Pages
{
    public class SampleControlSite
    {
        private readonly IWebBrowser _webBrowser;

        private const string ServerAddress = "http://the-internet.herokuapp.com/";

        public SampleControlSite(IWebBrowser webBrowser)
        {
            _webBrowser = webBrowser;
            _webBrowser.ServerAddress = new Uri(ServerAddress);
        }

        public MainPage MainPage { get { return new MainPage(_webBrowser); } }

        public DropDownPage DropDownPage { get { return new DropDownPage(_webBrowser); } }

    }
}
