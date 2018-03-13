using System;
using System.Collections.Generic;
using log4net;
using log4net.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FutureWonder.Exercises.Configuration
{
    using KVPList = IList<KeyValuePair<string, ConfigValue>>;

    [TestClass]
    public class ConfigTests
    {
        private readonly ILog _log = LogManager.GetLogger(nameof(ConfigTests));
        private readonly MockRepository _repository = new MockRepository(MockBehavior.Loose);
        private Mock<IPersistSource> _persistSource;
        private Config _config;

        public ConfigTests()
        {
            XmlConfigurator.Configure();
        }

        [TestInitialize]
        private void TestFrameworkInitialization()
        {
            _log.Info("Initializing Framework");
            _persistSource = _repository.Create<IPersistSource>();
            _config = new Config(_persistSource.Object);

        }

        [TestMethod]
        public void InitializeTest()
        {
            _log.Info("InitializeTest");

        }

        [TestMethod]
        public void LoadValueTest()
        {
            KVPList list = new List<KeyValuePair<string, ConfigValue>>();
            _persistSource.Setup(ps => ps.LoadValues(It.IsAny<List<string>>())).Returns(list);

        }

        [TestMethod]
        public void SaveValueTest()
        {
            _log.Info("SaveValueTest");

            // do the save operation

            // check for the persist call

            _persistSource.Verify(p => p.PersistValues(It.IsAny<List<KeyValuePair<string, ConfigValue>>> ()), Times.Once);
            throw new NotImplementedException();
        }
    }
}
