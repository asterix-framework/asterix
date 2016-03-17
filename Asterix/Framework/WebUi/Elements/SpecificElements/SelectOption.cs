using System;
using Asterix.Framework.WebUi.Logging;
using OpenQA.Selenium;

namespace Asterix.Framework.WebUi.Elements.SpecificElements
{
    public class SelectOption: SpecificElement, ISelectOption
    {
        public SelectOption(IWebDriver webDriver, ILogger logger, Func<IWebElement> webElementFunc)
            : base(webDriver, logger, webElementFunc)
        {
            Element = new Element(webDriver, webElementFunc, logger);
        }

        public bool Selected
        {
            get { return WebElement.Selected; }
        }

        public string Value
        {
            get { return Element.GetAttribute("value"); }
        }
    }
}