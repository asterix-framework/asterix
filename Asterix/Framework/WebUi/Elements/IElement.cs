using OpenQA.Selenium;

namespace Asterix.Framework.WebUi.Elements
{
    public interface IElement: IElementBase
    {
        string Text { get; }
        bool Displayed { get; }
        IWebDriver WebDriver { get; }
        void Click();
    }
}