namespace Asterix.Framework.WebUi.Elements.SpecificElements
{
    public interface ISelectOption : ISpecificElement
    {
        bool Selected { get; }
        string Value { get; }
    }
}