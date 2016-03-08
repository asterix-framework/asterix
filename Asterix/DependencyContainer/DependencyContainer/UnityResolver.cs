using System;
using System.Collections.Generic;
using Asterix.DependencyContainer.Contracts;
using Microsoft.Practices.Unity;

namespace Asterix.DependencyContainer
{
    public class UnityResolver : IResolver
    {
        private readonly IUnityContainer _unityContainer;

        public UnityResolver(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
        }

        public void RegisterType<TFrom, TTo>() where TTo : TFrom
        {
            _unityContainer.RegisterType<TFrom, TTo>();
        }

        public void RegisterInstance<TTo>(TTo instance)
        {
            _unityContainer.RegisterInstance(instance);
        }

        public void RegisterInstance<TTo>(Type interfaceType, TTo instance)
        {
            _unityContainer.RegisterInstance(interfaceType, instance);
        }

        public T Resolve<T>()
        {
            return _unityContainer.Resolve<T>();
        }

        public object Resolve(Type serviceType)
        {
            return _unityContainer.Resolve(serviceType);
        }

        public IEnumerable<object> ResolveAll(Type serviceType)
        {
            return _unityContainer.ResolveAll(serviceType);
        }
    }
}
