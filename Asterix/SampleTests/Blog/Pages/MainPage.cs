using Asterix.Framework.WebUi;
using Asterix.Framework.WebUi.Browser;
using Asterix.Framework.WebUi.Elements;
using TestContext.Page;

namespace SampleTests.Blog.Pages
{
    public class MainPage : PageBase
    {
        public MainPage(Browser browser) : base(browser) { }

        //[FindBy.Xpath("")]
        public string Title
        {
            get { return Browser.FindElement(FindBy.XPath("//*[@id=\"masthead\"]/div/h1/a")).Text; }
        }

        public InputElement Search
        {
            get { return Browser.FindElement<InputElement>(FindBy.Class("search-field")); }
        }

        public IElement FirstPostContainer
        {
            get { return Browser.FindElement(FindBy.Id("post-2")); }
        }

        public IElement FirstPostTitle
        {
            get { return FirstPostContainer.FindElement(FindBy.TagName("h1")); }
        }
    }
}