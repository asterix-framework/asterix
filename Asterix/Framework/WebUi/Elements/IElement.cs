using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Asterix.Framework.WebUi.Elements
{
    public interface IElement : IElementBase
    {
        string Text { get; }
        bool Displayed { get; }
        Actions Actions { get; }
        Javascript Javascript { get; }
        void Click();
        string GetAttribute(string attributeName);
        void SetAttribute(string key, string value);
    }
}