using System;
using Asterix.Framework.WebUi.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;

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

        public void Click()
        {
            WebElement.Click();
        }
    }
}
