using Asterix.Framework.WebUi.Browser;

namespace TestContext.Page
{
    public class PageBase
    {
        public Browser Browser { get; private set; }

        public PageBase(Browser browser)
        {
            Browser = browser;
        }

        public void Navigate(string url)
        {
            Browser.Navigate(url);
        }
    }
}
