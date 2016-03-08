using System;
using Asterix.Framework.WebUi.Logging;
using OpenQA.Selenium;

namespace Asterix.Framework.WebUi.Elements
{
    public abstract class SpecificElement : ElementBase
    {
        public IElement Element { get; set; }

        protected SpecificElement(IWebDriver webDriver, ILogger logger, Func<IWebElement> webElementFunc) : base(webDriver, logger, webElementFunc)
        {
        }
    }
}