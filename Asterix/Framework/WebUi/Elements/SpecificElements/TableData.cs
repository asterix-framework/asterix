using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asterix.Framework.WebUi.Logging;
using OpenQA.Selenium;

namespace Asterix.Framework.WebUi.Elements.SpecificElements
{
    public class TableData :SpecificElement,ITableData
    {
        public TableData() : base(null, null, null) { }
        public TableData(IWebDriver webDriver, ILogger logger, Func<IWebElement> webElementFunc) : base(webDriver, logger, webElementFunc)
        {
        }
    }
}
