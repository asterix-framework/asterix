using Asterix.Framework.WebUi;
using Asterix.Framework.WebUi.Browser;
using Asterix.Framework.WebUi.Elements;
using Asterix.Framework.WebUi.PageObject;

namespace SampleTests.SampleControlSite.Pages
{
    public class FramePage : PageBase
    {
        public FramePage(IWebBrowser webBrowser) : base(webBrowser)
        {
        }

        protected override string PageUrl => "/iframe";

        public EditorControl EditorFrame => new EditorControl(WebBrowser.SwitchToFrame("mce_0_ifr"));

        public IWebBrowser DefaultBrowser
        {
            get
            {
                WebBrowser = WebBrowser.SwitchToDefaultContent();
                return WebBrowser;
            }
        }

        public IElement FileButton => DefaultBrowser.FindElement(FindBy.Id("mceu_15-open"));
    }

    public class EditorControl : ControlBase
    {
        public EditorControl(IWebBrowser webBrowser) : base(webBrowser) { }

        public IElement Body => WebBrowser.FindElement(FindBy.Id("tinymce"));
    }
}
