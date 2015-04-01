using Microsoft.VisualStudio.TestTools.UnitTesting;
using oncast_taos.src;
using oncast_taos.src.exception;

namespace oncast_taos.test
{
    [TestClass]
    public class ConfigurationTest
    {
        Configuration config;

        [TestInitialize()]
        public void Initialize()
        {
            config = Configuration.Instance;
        }

        [TestMethod]
        [ExpectedException(typeof(OrderingException), "Order.config cant be read.")]
        public void Should_Throw_OrderingException_When_OrderConfig_NotExists()
        {
           config.loadConfigurationFile("test.config");
        }

        [TestMethod]
        [ExpectedException(typeof(OrderingException), "Order.config cant be Null or Empty.")]
        public void Should_Throw_OrderingException_When_OrderConfig_IsNull()
        {
            config.loadConfiguration(null);
        }

        [TestMethod]
        [ExpectedException(typeof(OrderingException), "Invalid Order.config content.")]
        public void Should_Throw_OrderingException_When_Invalid_OrderConfig()
        {
            config.loadConfiguration("{ 'Property': 'Title', 'Direction': 'Ascendent' }");
        }
    }
}
