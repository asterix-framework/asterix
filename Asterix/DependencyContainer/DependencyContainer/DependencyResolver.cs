using Asterix.DependencyContainer.Contracts;
using Microsoft.Practices.Unity;

namespace Asterix.DependencyContainer
{
    public class DependencyResolver
    {
        public static IUnityContainer UnityContainer { get; private set; }

        public static IResolver Instance { get; private set; }

        static DependencyResolver()
        {
            UnityContainer = new UnityContainer();
            Instance = new UnityResolver(UnityContainer);
        }

        public static void SetResolver(IUnityContainer unityContainer)
        {
            UnityContainer = unityContainer;
            Instance = new UnityResolver(unityContainer);
        }
    }
}
