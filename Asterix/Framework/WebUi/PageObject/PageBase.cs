using System;

namespace Asterix.Framework.WebUi.PageObject
{
    public abstract class PageBase
    {
        public Browser.IWebBrowser WebBrowser { get; private set; }

        public PageBase(Browser.IWebBrowser webBrowser)
        {
            WebBrowser = webBrowser;
        }

        protected abstract string PageUrl{ get; }

        public void Navigate()
        {
            WebBrowser.Navigate(new Uri(WebBrowser.ServerAddress, PageUrl));
        }
    }
}
