namespace Asterix.Framework.WebUi.Elements.SpecificElements
{
    public interface IInputElement : ISpecificElement
    {
        void Type(string text);
        void Clear();
        void SetValue(string value);
    }
}