using Asterix.Framework.WebUi;
using Asterix.Framework.WebUi.Browser;
using Asterix.Framework.WebUi.Elements;
using Asterix.Framework.WebUi.Elements.SpecificElements;
using Asterix.Framework.WebUi.PageObject;

namespace SampleTests.google.Pages
{
    public class MainPage : PageBase
    {
        public MainPage(IWebBrowser webBrowser) : base(webBrowser) { }

        public IInputElement Search { get { return WebBrowser.FindElement<InputElement>(FindBy.Id("lst-ib")); } }

        public IElement SearchButton { get { return WebBrowser.FindElement(FindBy.XPath("//*[@id=\"sblsbb\"]/button")); } }

        public IElement CalculatorResult { get { return WebBrowser.FindElement(FindBy.Id("cwos")); } }

        protected override string PageUrl { get { return "/"; } }
    }
}