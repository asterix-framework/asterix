using System;
using Asterix.Core.Contracts;

namespace Asterix.Core
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
