using Asterix.DependencyContainer.Contracts;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Asterix.DependencyContainer.Tests
{
    [TestClass]
    public class UnityResolverTests
    {
        private IUnityContainer _unityContainer;
        private IResolver _unityResolver;

        [TestInitialize]
        public void TestInit()
        {
            _unityContainer = Substitute.For<IUnityContainer>();
            _unityContainer.Resolve<ITest>().Returns(new Test());

            _unityResolver = new UnityResolver(_unityContainer);
        }

        [TestMethod]
        public void Resolve_Returns_Instance()
        {
            var test = _unityResolver.Resolve<ITest>();

            _unityContainer.Received().Resolve<ITest>();
            Assert.IsInstanceOfType(test, typeof(Test));
        }

        [TestMethod]
        public void ResolveWithParameterAsType_Returns_Instance()
        {
            var test = _unityResolver.Resolve(typeof(ITest));

            _unityContainer.Received().Resolve(typeof(ITest));
            Assert.IsInstanceOfType(test, typeof(Test));
        }
        
        [TestMethod]
        public void RegisterType_Calls_UnityMethod()
        {
            _unityResolver.RegisterType<ITest, Test>();

            _unityContainer.Received().RegisterType<ITest, Test>();
        }

        [TestMethod]
        public void RegisterInstance_Calls_UnityMethod()
        {
            Test test = new Test();

            _unityResolver.RegisterInstance(test);

            _unityContainer.ReceivedWithAnyArgs().RegisterInstance(test);
        }
    }

    interface ITest
    {

    }

    class Test : ITest
    {

    }
}
