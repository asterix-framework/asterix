using System;
using Asterix.Framework.WebUi.Browser;

namespace SampleTests.Blog.Pages
{
    public class ProfTestBlog
    {
        private readonly IWebBrowser _webBrowser;

        private const string ServerAddress = "https://professionaltestingblog.wordpress.com/";

        public ProfTestBlog(IWebBrowser webBrowser)
        {
            _webBrowser = webBrowser;
            _webBrowser.ServerAddress = new Uri(ServerAddress);
        }

        public MainPage MainPage { get { return new MainPage(_webBrowser); } }
    }
}
