using System.Collections.Generic;
using System.Linq;

namespace Asterix.Framework.WebUi.Elements.SpecificElements
{
    public class SelectElement : SpecificElement, ISelectElement
    {
        public SelectElement() : base(null, null, null)
        { }

        public SelectElement(IElement element) : base(element.WebDriver, element.Logger, element.WebElementFunc)
        {
            Element = element;
        }

        public SelectElementJavascript Javascript
        {
            get { return new SelectElementJavascript(WebDriver, WebElement); }
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

        public IEnumerable<ISelectOption> Options
        {
            get
            {
                var element = new OpenQA.Selenium.Support.UI.SelectElement(WebElement);
                return element.Options.Select(o => new SelectOption(WebDriver, Logger, () => o));
            }
        }

        public ISelectOption SelectedOption
        {
            get { return Options.Single(o => o.Selected); }
        }
    }
}
