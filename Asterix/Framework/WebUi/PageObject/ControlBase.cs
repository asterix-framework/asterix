namespace Asterix.Framework.WebUi.PageObject
{
    public class ControlBase
    {
        public Browser.IWebBrowser WebBrowser { get; protected set; }

        public ControlBase(Browser.IWebBrowser webBrowser)
        {
            WebBrowser = webBrowser;
        }
    }
}
