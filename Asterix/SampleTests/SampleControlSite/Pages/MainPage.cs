using System.Net.NetworkInformation;
using Asterix.Framework.WebUi;
using Asterix.Framework.WebUi.Browser;
using Asterix.Framework.WebUi.Elements;
using Asterix.Framework.WebUi.PageObject;
using System.Collections.Generic;

namespace SampleTests.SampleControlSite.Pages
{
    public class MainPage : PageBase
    {
        public MainPage(IWebBrowser webBrowser) : base(webBrowser)
        {
        }

        protected override string PageUrl { get { return "/"; } }

        public DropDownPage ClickOnDropDown()
        {
            DrowpDown.Click();
            return new DropDownPage(WebBrowser);
        }

        public CheckBoxPage ClickOnCheckBox()
        {
            CheckBox.Click();
            return new CheckBoxPage(WebBrowser);
        }

        public IElement DrowpDown
        {
            get
            {
                return WebBrowser.FindElement(FindBy.XPath("//*[@id=\"content\"]/ul/li[9]/a"));
            } 
            
        }

        public IElement CheckBox
        {
            get
            {
                return  WebBrowser.FindElement(FindBy.XPath("//*[@id=\"content\"]/ul/li[5]/a"));
            }
        }

        public List<IElement> ImmediateDescandantDivs
        {
            get
            {
                return WebBrowser.FindElements(FindBy.TagName("div"), true);
            }
        }
    }
}