using Asterix.Framework.WebUi.Logging;
using OpenQA.Selenium;

namespace Asterix.Framework.WebUi.Elements
{
    public interface IElementBase
    {
        ILogger Logger { get; }
        IWebElement WebElement { get; }
        IElement FindElement(FindBy by);
        T FindElement<T>(FindBy by) where T : ElementBase, new();
    }
}