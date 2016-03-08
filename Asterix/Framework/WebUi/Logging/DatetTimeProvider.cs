using System;

namespace Asterix.Framework.WebUi.Logging
{
    public class DatetTimeProvider : IDatetTimeProvider
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }

        public DateTime UtcNow()
        {
            return DateTime.UtcNow;
        }
    }
}
