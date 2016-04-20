using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asterix.Framework.WebUi.Logging;
using OpenQA.Selenium;

namespace Asterix.Framework.WebUi.Elements.SpecificElements
{
    public class TableRow: SpecificElement, ITableRow
    {
        public TableRow():base(null, null, null) { }

        public TableRow(IWebDriver webDriver, ILogger logger, Func<IWebElement> webElementFunc) : base(webDriver, logger, webElementFunc)
        {
        }

        public IList<TableData> Columns
        {
            get { return FindElements<TableData>(FindBy.Name("td")); }
        }

        public IList<TableData> HeaderColumns
        {
            get { return FindElements<TableData>(FindBy.Name("th")); }
        }
    }
}
