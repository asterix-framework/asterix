using System.Collections.Generic;

namespace Asterix.Framework.WebUi.Elements.SpecificElements
{
    public interface ISelectElement : ISpecificElement
    {
        void SelectByText(string text);
        SelectElementJavascript Javascript { get; }
        IEnumerable<ISelectOption> Options { get; }
        ISelectOption SelectedOption { get; }
        void SelectByIndex(int index);
        void SelectByValue(string value);
    }
}