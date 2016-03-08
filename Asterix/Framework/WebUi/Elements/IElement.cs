using OpenQA.Selenium;

namespace Asterix.Framework.WebUi.Elements
{
    public interface IElement: IElementBase
    {
        string Text { get; }
        IWebDriver WebDriver { get; }
    }
}