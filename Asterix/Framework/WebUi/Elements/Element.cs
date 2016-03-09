using System;
using Asterix.Framework.WebUi.Logging;
using OpenQA.Selenium;

namespace Asterix.Framework.WebUi.Elements
{
    public class Element : ElementBase, IElement
    {
        internal Element(IWebDriver webDriver, Func<IWebElement> webElement, ILogger logger): base(webDriver, logger, webElement)
        {
        }

        public string Text
        {
            get
            {
                return WebElement.Text;
            }
        }

        public bool Displayed
        {
            get
            {
                return WebElement.Displayed;
            }
        }
        
        public void Click()
        {
            WebElement.Click();
        }
    }
}
