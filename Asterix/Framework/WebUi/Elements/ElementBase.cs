using System;
using Asterix.Core.Contracts.Logging;
using Asterix.Framework.WebUi.Exceptions;
using OpenQA.Selenium;

namespace Asterix.Framework.WebUi.Elements
{
    public class ElementBase : IElementBase
    {
        public Func<IWebElement> WebElementFunc { get; }
        public ILogger Logger { get; private set; }
        public IWebDriver WebDriver { get; private set; }

        public ElementBase(IWebDriver webDriver, ILogger logger, Func<IWebElement> webElementFunc)
        {
            WebElementFunc = webElementFunc;
            Logger = logger;
            WebDriver = webDriver;
        }

        public IWebElement WebElement { get { return WebElementFunc.Invoke(); } }
        
        private Func<IWebElement> GetFindElementFunc(FindBy by)
        {

            return () => WebElementFunc.Invoke().FindElement(@by.SeleniumBy);
        }

        public IElement FindElement(FindBy by)
        {
            try
            {
                return new Element(WebDriver, GetFindElementFunc(by), Logger);
            }
            catch (NoSuchElementException exc)
            {
                throw new ElementNotFoundException("Element was not found: " + by, exc);
            }
        }

        public T FindElement<T>(FindBy by) where T : ElementBase, new()
        {
            var element = new Element(WebDriver, GetFindElementFunc(by), Logger);

            return (T)Activator.CreateInstance(typeof(T), element);
        }
    }
}