using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asterix.Framework.WebUi.Elements.SpecificElements
{
    public interface ICheckAbleElement : ISpecificElement
    {
        bool Checked { get;}

        void Check();
    }
}
