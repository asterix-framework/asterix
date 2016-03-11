using System;
using System.Text;
using OpenQA.Selenium;

namespace Asterix.Framework.WebUi.Elements
{
    public class Javascript
    {
        private readonly IWebElement _webElement;
        private readonly IJavaScriptExecutor _javaScriptExecutor;

        public Javascript(IWebDriver webDriver, IWebElement webElement)
        {
            _webElement = webElement;
            _javaScriptExecutor = webDriver as IJavaScriptExecutor;
        }

        public void SetValue(string value)
        {
            _javaScriptExecutor.ExecuteScript("arguments[0].setAttribute('value', '" + value + "')", _webElement);
        }

        public void Click()
        {
            _javaScriptExecutor.ExecuteScript("arguments[0].click();", _webElement);
        }

        public void FireEvent(string eventName)
        {
            var scriptCode = new StringBuilder();
            scriptCode.AppendLine("var newEvt = document.createEventObject();");
            scriptCode.AppendLine(String.Format("arguments[0].fireEvent('{0}', newEvt);", eventName));
            _javaScriptExecutor.ExecuteScript(scriptCode.ToString(), _webElement);
        }

        public void SetAttribute(string attributeName, string attributeValue)
        {
            _javaScriptExecutor.ExecuteScript("arguments[0].setAttribute('" + attributeName + "',arguments[1]);", _webElement, attributeValue);
        }
    }
}