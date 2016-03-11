using Asterix.Framework.WebUi;
using Asterix.Framework.WebUi.Browser;
using Asterix.Framework.WebUi.Elements;
using Asterix.Framework.WebUi.Elements.SpecificElements;
using Asterix.Framework.WebUi.PageObject;

namespace SampleTests.Blog.Pages
{
    public class MainPage : PageBase
    {
        public MainPage(IWebBrowser webBrowser) : base(webBrowser) { }

        //[FindBy.Xpath("")]
        public string Title
        {
            get { return WebBrowser.FindElement(FindBy.XPath("//*[@id=\"masthead\"]/div/h1/a")).Text; }
        }

        public InputElement Search
        {
            get { return WebBrowser.FindElement<InputElement>(FindBy.Class("search-field")); }
        }

        public IElement FirstPostContainer
        {
            get { return WebBrowser.FindElement(FindBy.Id("post-2")); }
        }

        public IElement FirstPostTitle
        {
            get { return FirstPostContainer.FindElement(FindBy.TagName("h1")); }
        }

        protected override string PageUrl { get { return "/"; } }
    }
}