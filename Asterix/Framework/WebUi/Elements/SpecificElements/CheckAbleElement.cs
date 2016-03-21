using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asterix.Framework.WebUi.Elements.SpecificElements
{
    public abstract class CheckAbleElement : SpecificElement, ICheckAbleElement
    {
        protected CheckAbleElement() : base(null, null, null)
        {
        }

        protected CheckAbleElement(IElement element) : base(element.WebDriver, element.Logger, element.WebElementFunc)
        {
            Element = element;
        }
        public bool Checked
        {
            get { return IsCheked(); }
        }

        public void Check()
        {
            if (!IsCheked())
            {
                Element.Click();
            }
        }

        protected bool IsCheked()
        {
            return Element.WebElement.Selected;
        }
    }
}
