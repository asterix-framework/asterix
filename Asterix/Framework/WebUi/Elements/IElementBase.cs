using System;
using System.Collections.Generic;
using Asterix.Framework.WebUi.Logging;
using OpenQA.Selenium;

namespace Asterix.Framework.WebUi.Elements
{
    public interface IElementBase
    {
        ILogger Logger { get; }
        IWebElement WebElement { get; }
        Func<IWebElement> WebElementFunc { get; }
        IWebDriver WebDriver { get; }
        IElement FindElement(FindBy by);
        T FindElement<T>(FindBy by) where T : IElementBase, new();
    }
}