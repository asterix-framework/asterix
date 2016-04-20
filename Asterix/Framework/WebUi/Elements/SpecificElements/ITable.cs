using System.Collections.Generic;

namespace Asterix.Framework.WebUi.Elements.SpecificElements
{
    public interface ITable
    {
        IList<TableRow> Rows { get; }
    }
}
