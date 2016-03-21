namespace Asterix.Framework.WebUi.Elements.SpecificElements
{
    public class CheckBoxElement : CheckAbleElement, ICheckBoxElement
    {
        public CheckBoxElement()
        {
        }

        public CheckBoxElement(IElement element) : base(element)
        {
            Element = element;
        }

        public void UnCheck()
        {
            if (IsCheked())
            {
                Element.Click();
            }
        }
    }
}
