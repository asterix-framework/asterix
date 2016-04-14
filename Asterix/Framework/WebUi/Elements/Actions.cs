using OpenQA.Selenium;

namespace Asterix.Framework.WebUi.Elements
{
    public class Actions
    {
        private readonly IWebElement _webElement;

        public OpenQA.Selenium.Interactions.Actions WebDriverActions { get; set; }

        public Actions(IWebDriver webDriver, IWebElement webElement)
        {
            _webElement = webElement;
            WebDriverActions = new OpenQA.Selenium.Interactions.Actions(webDriver);
        }

        public void Click()
        {
            WebDriverActions.Click(_webElement).Build().Perform();
        }

        public void DragAndDropTo(IElement destinationElement)
        {
            WebDriverActions.DragAndDrop(_webElement, destinationElement.WebElement).Build().Perform();
        }

        public void DragAndDropToOffset(int x, int y)
        {
            WebDriverActions.DragAndDropToOffset(_webElement, x, y).Build().Perform();
        }

        public void DoubleClick()
        {
            WebDriverActions.DoubleClick(_webElement).Build().Perform();
        }

        public void ClickAndHold()
        {
            WebDriverActions.ClickAndHold(_webElement).Build().Perform();
        }

        public void ContextClick()
        {
            WebDriverActions.ContextClick(_webElement).Build().Perform();
        }

        public void KeyUp(string key)
        {
            WebDriverActions.KeyUp(_webElement, key).Build().Perform();
        }

        public void KeyDown(string key)
        {
            WebDriverActions.KeyDown(_webElement, key).Build().Perform();
        }

        public void SendKeys(string keysToSend)
        {
            WebDriverActions.SendKeys(_webElement, keysToSend).Build().Perform();
        }

        public void MoveByOffset(int x, int y)
        {
            WebDriverActions.MoveByOffset(x, y).Build().Perform();
        }

        public void MoveToElement(IElement toElement, int x, int y)
        {
            WebDriverActions.MoveToElement(toElement.WebElement, x, y).Build().Perform();
        }

        public void Perform()
        {
            WebDriverActions.Perform();
        }
    }

}
