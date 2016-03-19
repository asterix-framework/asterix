using Asterix.Framework.WebUi;
using Asterix.Framework.WebUi.Browser;
using Asterix.Framework.WebUi.Elements.SpecificElements;
using Asterix.Framework.WebUi.PageObject;

namespace SampleTests.SampleControlSite.Pages
{
    public class DropDownPage : PageBase
    {
        public DropDownPage(IWebBrowser webBrowser) : base(webBrowser)
        {
        }

        protected override string PageUrl { get { return "dropdown"; } }

        public ISelectElement DropDownElement
        {
            get { return WebBrowser.FindElement<SelectElement>(FindBy.Id("dropdown")); }
        }
    }
}