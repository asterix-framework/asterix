using System;

namespace Asterix.Framework.WebUi.Exceptions
{
    internal class ElementNotFoundException : Exception
    {
        public ElementNotFoundException(string message, Exception ex = null)
            : base(message, ex)
        {
        }
    }
}
