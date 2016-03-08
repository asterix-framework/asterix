using System;

namespace Asterix.Framework.WebUi.Logging
{
    public interface IDatetTimeProvider
    {
        DateTime Now();
        DateTime UtcNow();
    }
}