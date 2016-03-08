using System;

namespace Asterix.Core.Contracts
{
    public interface IDatetTimeProvider
    {
        DateTime Now();
        DateTime UtcNow();
    }
}