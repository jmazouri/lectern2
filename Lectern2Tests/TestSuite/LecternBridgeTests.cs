using System.Linq;
using Lectern2.Messages;
using Lectern2Tests.TestSuite.TestClasses;
using Xunit;

namespace Lectern2Tests.TestSuite
{
    public class LecternBridgeTests : BaseTest
    {
        private readonly TestLecternBridge _testBridge;

        private TestLecternBridge TestBridge
        {
            get { return _testBridge; }
        }

        public LecternBridgeTests(ContainerFixture fixture)
        {
            _testBridge = fixture.TestLectern.Mediator.NetworkSystem.Bridges.Single(bridge => bridge.Name == "TestBridge") as TestLecternBridge;
            Assert.NotNull(_testBridge);
        }

        [Fact]
        public void TestInitialization()
        {
            Assert.Equal(TestBridge.Name, "TestBridge");

            Assert.NotNull(TestBridge.Network);

            Assert.True(TestBridge.Network.Bridges.Count == 1, "TestBridge's network contains more than one bridge");
            Assert.Contains(TestBridge.Network.Bridges, bridge => bridge == TestBridge);

            Assert.True(TestBridge.Network.Plugins.Count == 2, "TestBridge's network contains more than two plugins");
            Assert.Contains(TestBridge.Network.Plugins, plugin => plugin.GetType() == typeof(TestLecternPlugin));
        }

        [Fact]
        public void TestReceiveMessage()
        {
            TestBridge.ReceiveMessage(new LecternMessage("Hello Test!"));
        }
    }
}
