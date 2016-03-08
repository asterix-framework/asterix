using System;
using System.Collections.Generic;

namespace Asterix.DependencyContainer.Contracts
{
    public interface IResolver
    {
        void RegisterType<TFrom, TTo>() where TTo : TFrom;
        void RegisterInstance<TTo>(TTo instance);
        void RegisterInstance<TTo>(Type interfaceType, TTo instance);
        T Resolve<T>();
        object Resolve(Type serviceType);
        IEnumerable<object> ResolveAll(Type serviceType);
    }
}
