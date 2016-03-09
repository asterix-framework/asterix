using OpenQA.Selenium;

namespace Asterix.Framework.WebUi.Elements.SpecificElements
{
    public class InputElement : SpecificElement, IInputElement
    {
        public InputElement() : base(null, null, null)
        { }

        public InputElement(Element element) : base(element.WebDriver, element.Logger, element.WebElementFunc)
        {
            Element = element;
        }
        
        public void Type(string text)
        {
            Element.WebElement.SendKeys(text);
        }

        public void Clear()
        {
            Element.WebElement.Clear();
        }
        
        public void SetValue(string value)
        {
            var executor = WebDriver as IJavaScriptExecutor;
            executor.ExecuteScript("arguments[0].setAttribute('value', '" + value + "')", WebElement);
        }
    }
}
