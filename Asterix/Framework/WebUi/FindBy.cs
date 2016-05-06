namespace Asterix.Framework.WebUi
{
    public class FindBy
    {
        public FindBy()
        {
            XPathQueryPrefix = "./*//";
        }

        private string XPathQuery { get; set; }

        private string XPathQueryPrefix { get; set; }

        internal OpenQA.Selenium.By SeleniumBy
        {
            get { return OpenQA.Selenium.By.XPath(XPathQueryPrefix + XPathQuery); }
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

        public void SetSearchDepth(bool onlyImmediateDescendants)
        {
            XPathQueryPrefix = onlyImmediateDescendants ? "./*/" : "/*//";
        }
    }
}
