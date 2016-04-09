using System;
using System.Collections.Generic;
using Asterix.Framework.WebUi.Exceptions;
using Asterix.Framework.WebUi.Logging;
using OpenQA.Selenium;

namespace Asterix.Framework.WebUi.Elements
{
    public abstract class ElementBase : IElementBase
    {
        public Func<IWebElement> WebElementFunc { get; private set; }
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

        public List<IElement> FindElements(FindBy by)
        {
            var elements = new List<IElement>();
            var elementsCount = ElementsCount(@by);
            for (var i = 0; i < elementsCount; i++)
            {
                int index = i;
                elements.Add(CreateElementByIndex(@by, index));
            }


            return elements;
        }

        public List<T> FindElements<T>(FindBy by) where T : IElementBase, new()
        {
            var elements = new List<T>();
            var elementsCount = ElementsCount(@by);
            for (var i = 0; i < elementsCount; i++)
            {
                int index = i;
                var element = CreateElementByIndex(@by, index);
                elements.Add((T)Activator.CreateInstance(typeof(T), element));
            }

            return elements;
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

        public T FindElement<T>(FindBy by) where T : IElementBase, new()
        {
            var element = FindElement(by);
            return (T)Activator.CreateInstance(typeof(T), element);
        }

        private int ElementsCount(FindBy by)
        {
            return WebElement.FindElements(by.SeleniumBy).Count;
        }

        private Element CreateElementByIndex(FindBy @by, int index)
        {
            return new Element(WebDriver, () => WebElement.FindElements(@by.SeleniumBy)[index], Logger);
        }
    }
}