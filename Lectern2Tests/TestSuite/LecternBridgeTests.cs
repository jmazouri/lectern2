using Lectern2.Messages;
using Xunit;

namespace Lectern2Tests.TestSuite
{
    public class LecternBridgeTests : BaseTest
    {
        [Fact]
        public void TestReceiveMessage()
        {
            Assert.NotNull(Bridge);
            Bridge.ReceiveMessage(new LecternMessage("Hello Test!"));
        }
    }
}
