using System;
using OpenQA.Selenium;

namespace Asterix.Framework.WebUi
{
    public class FindBy
    {
        private By _preDefinedSeleniumBy;

        public FindBy()
        {
            XPathQueryPrefix = "./*//";
        }

        private string XPathQuery { get; set; }

        private string XPathQueryPrefix { get; set; }

        internal OpenQA.Selenium.By SeleniumBy
        {
            get { return _preDefinedSeleniumBy ?? OpenQA.Selenium.By.XPath(XPathQueryPrefix + XPathQuery); }
            set { _preDefinedSeleniumBy = value; }
        }
        
        public static FindBy Id(string value)
        {
            return new FindBy { XPathQuery = $"*[@id='{value}']" };
        }

        public static FindBy Name(string value)
        {
            return new FindBy { XPathQuery = $"*[@name='{value}']" };
        }

        public static FindBy XPath(string value)
        {
            return new FindBy { XPathQuery = value, XPathQueryPrefix = string.Empty};
        }

        public static FindBy Class(string value)
        {
            return new FindBy { XPathQuery = $"*[@class='{value}']" };
        }

        public static FindBy TagName(string value)
        {
            return new FindBy { XPathQuery = $"*[contains(local-name(), '{value}')]" };
        }

        public static FindBy Text(string value)
        {
            return new FindBy { XPathQuery = $"*[contains(text(), '{value}')]" };
        }

        public static FindBy Attribute(string attributeName, string attributeValue)
        {
            return new FindBy { XPathQuery = $"*[@{attributeName}='{attributeValue}']" };
        }

        public static FindBy Value(string valueText)
        {
            return new FindBy { XPathQuery = $"*[@value='{valueText}']" };
        }

        public static FindBy Css(string text)
        {
            return new FindBy { SeleniumBy = OpenQA.Selenium.By.CssSelector(text) };
        }

        public static FindBy LinkText(string text)
        {
            return new FindBy { SeleniumBy = OpenQA.Selenium.By.LinkText(text) };
        }

        public static FindBy PartialLinkText(string text)
        {
            return new FindBy { SeleniumBy = OpenQA.Selenium.By.PartialLinkText(text) };
        }

        public void SetSearchDepth(bool onlyImmediateDescendants)
        {
            XPathQueryPrefix = onlyImmediateDescendants ? "./*/" : "/*//";
        }
    }
}
