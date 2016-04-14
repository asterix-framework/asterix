using Asterix.Framework.WebUi;
using Asterix.Framework.WebUi.Browser;
using Asterix.Framework.WebUi.Elements;
using Asterix.Framework.WebUi.PageObject;

namespace SampleTests.SampleControlSite.Pages
{
    public class DragAndDropPage : PageBase
    {
        public DragAndDropPage(IWebBrowser webBrowser) : base(webBrowser) { }

        protected override string PageUrl { get { return "drag_and_drop"; } }

        public IElement RectangleA
        {
            get { return WebBrowser.FindElement(FindBy.Id("column-a")); }
        }

        public IElement RectangleB
        {
            get { return WebBrowser.FindElement(FindBy.Id("column-b")); }
        }
    }
}