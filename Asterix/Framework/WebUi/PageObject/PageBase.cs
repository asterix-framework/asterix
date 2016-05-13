using System;

namespace Asterix.Framework.WebUi.PageObject
{
    public abstract class PageBase : ControlBase
    {
        protected PageBase(Browser.IWebBrowser webBrowser) : base(webBrowser) { }

        protected abstract string PageUrl{ get; }

        public void Navigate()
        {
            WebBrowser.Navigate(new Uri(WebBrowser.ServerAddress, PageUrl));
        }
    }
}
