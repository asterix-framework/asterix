using System;

namespace Asterix.Framework.WebUi.Exceptions
{
    internal class FrameNotFoundException: Exception
    {
        public FrameNotFoundException(string message, Exception ex = null)
           : base(message, ex)
        {
        }
    }
}
