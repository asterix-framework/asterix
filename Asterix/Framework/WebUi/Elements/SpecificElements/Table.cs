using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asterix.Framework.WebUi.Logging;
using OpenQA.Selenium;

namespace Asterix.Framework.WebUi.Elements.SpecificElements
{
    public class Table: SpecificElement, ITable
    {
        public Table(): base(null, null, null)
        { }
        public Table(IWebDriver webDriver, ILogger logger, Func<IWebElement> webElementFunc) : base(webDriver, logger, webElementFunc)
        {
        }

        public IList<TableRow> Rows { get { return FindElements<TableRow>(FindBy.TagName("tr")); } }
    }
}
