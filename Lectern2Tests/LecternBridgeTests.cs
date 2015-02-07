using Lectern2;
using Xunit;

namespace Lectern2Tests
{
    public class LecternBridgeTests : BaseTest
    {
        [Fact]
        public void TestRecieveMessage()
        {
            Assert.NotNull(bridge);
            bridge.RecieveMessage(new LecternMessage("Hello Test!"));
        }
    }
}
