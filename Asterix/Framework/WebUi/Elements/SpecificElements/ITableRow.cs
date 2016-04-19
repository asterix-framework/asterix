using System.Collections.Generic;

namespace Asterix.Framework.WebUi.Elements.SpecificElements
{
    public interface ITableRow
    {
        IEnumerable<TableData>  Columns { get; }

        IEnumerable<TableData> HeaderColumns { get; }
    }
}
