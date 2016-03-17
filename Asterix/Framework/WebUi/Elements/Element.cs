using System;
using Asterix.Framework.WebUi.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Asterix.Framework.WebUi.Elements
{
    public class Element : ElementBase, IElement
    {
        internal Element(IWebDriver webDriver, Func<IWebElement> webElement, ILogger logger): base(webDriver, logger, webElement)
        {
        }

        public Actions Actions { get { return new Actions(WebDriver); } }

        public Javascript Javascript { get {  return new Javascript(WebDriver, WebElement); } }

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

        public string GetAttribute(string attributeName)
        {
            return WebElement.GetAttribute(attributeName);
        }
    }
}
