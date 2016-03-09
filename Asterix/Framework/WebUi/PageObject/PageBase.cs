namespace Asterix.Framework.WebUi.PageObject
{
    public class PageBase
    {
        public Browser.Browser Browser { get; private set; }

        public PageBase(Browser.Browser browser)
        {
            Browser = browser;
        }

        public void Navigate(string url)
        {
            Browser.Navigate(url);
        }
    }
}
