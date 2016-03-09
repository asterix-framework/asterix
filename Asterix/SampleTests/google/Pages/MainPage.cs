using Asterix.Framework.WebUi;
using Asterix.Framework.WebUi.Browser;
using Asterix.Framework.WebUi.Elements;
using Asterix.Framework.WebUi.Elements.SpecificElements;
using Asterix.Framework.WebUi.PageObject;

namespace SampleTests.google.Pages
{
    public class MainPage : PageBase
    {
        public MainPage(Browser browser) : base(browser) { }

        public IInputElement Search { get { return Browser.FindElement<InputElement>(FindBy.Id("lst-ib")); } }

        public IElement SearchButton { get { return Browser.FindElement(FindBy.XPath("//*[@id=\"sblsbb\"]/button")); } }
    }
}