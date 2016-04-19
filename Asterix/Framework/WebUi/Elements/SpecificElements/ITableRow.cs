using System.Collections.Generic;

namespace Asterix.Framework.WebUi.Elements.SpecificElements
{
    public interface ITableRow
    {
        IList<TableData>  Columns { get; }

        IList<TableData> HeaderColumns { get; }
    }
}
