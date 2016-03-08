using Asterix.Core.Contracts;
using Asterix.DependencyContainer.Contracts;

namespace Asterix.Core.Configuration
{
    public class DependencyConiguration
    {
        public static void Configure(IResolver resolver)
        {
            resolver.RegisterType<IDatetTimeProvider, DatetTimeProvider>();
        }
    }
}
