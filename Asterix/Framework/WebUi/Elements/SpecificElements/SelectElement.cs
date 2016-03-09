namespace Asterix.Framework.WebUi.Elements.SpecificElements
{
    public class SelectElement : SpecificElement, ISelectElement
    {
        public SelectElement() : base(null, null, null)
        { }

        public SelectElement(Element element) : base(element.WebDriver, element.Logger, element.WebElementFunc)
        {
            Element = element;
        }

        public void SelectByText(string text)
        {
            var element = new OpenQA.Selenium.Support.UI.SelectElement(WebElement);
            element.SelectByText(text);
        }

        public void SelectByIndex(int index)
        {
            var element = new OpenQA.Selenium.Support.UI.SelectElement(WebElement);
            element.SelectByIndex(index);
        }

        public void SelectByValue(string value)
        {
            var element = new OpenQA.Selenium.Support.UI.SelectElement(WebElement);
            element.SelectByValue(value);
        }
    }
}
