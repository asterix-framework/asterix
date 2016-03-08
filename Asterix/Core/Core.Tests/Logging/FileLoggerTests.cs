using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Asterix.Core.Contracts.Tests.Logging
{
    [TestClass]
    public class FileLoggerTests
    {
        private ILogger _logger;
        private IDatetTimeProvider _datetTimeProvider;

        [TestInitialize]
        public void TestInit()
        {
            _datetTimeProvider = Substitute.For<IDatetTimeProvider>();
            _datetTimeProvider.Now().Returns(DateTime.Now);
            _logger = new FileLogger(_datetTimeProvider);
        }

        [TestMethod]
        public void Info_Calls_Datetimeprovider_Now()
        {
            _logger.Info("Testlog");

            _datetTimeProvider.Received().Now();
        }
    }
}
