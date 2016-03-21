using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asterix.Framework.WebUi.Logging;
using OpenQA.Selenium;

namespace Asterix.Framework.WebUi.Elements.SpecificElements
{
    public class RadionButtonElement : CheckAbleElement, IRadioButtonElement
    {
        public RadionButtonElement()
        {
        }
        public RadionButtonElement(IElement element) : base(element)
        {
            Element = element;
        }
    }
}
