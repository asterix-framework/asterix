using OpenQA.Selenium.Internal;

namespace Asterix.Framework.WebUi
{
    public class FindBy
    {
        internal OpenQA.Selenium.By SeleniumBy { get; set; }

        public static FindBy Id(string value)
        {
            return new FindBy { SeleniumBy = OpenQA.Selenium.By.Id(value) };
        }

        public static FindBy Name(string value)
        {
            return new FindBy { SeleniumBy = OpenQA.Selenium.By.Name(value) };
        }

        public static FindBy XPath(string value)
        {
            return new FindBy { SeleniumBy = OpenQA.Selenium.By.XPath(value) };
        }

        public static FindBy Class(string value)
        {
            return new FindBy { SeleniumBy = OpenQA.Selenium.By.ClassName(value) };
        }

        public static FindBy TagName(string value)
        {
            return new FindBy() { SeleniumBy = OpenQA.Selenium.By.TagName(value) };
        }

        public static FindBy Text(string value)
        {
            return new FindBy() { SeleniumBy = OpenQA.Selenium.By.XPath(($"//*[contains(text(), '{value}')]")) };
        }
    }
}
