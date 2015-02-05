using Lectern2;
using Xunit;
using Xunit.Ioc;

namespace Lectern2Tests
{
    [RunWith(typeof(IocTestClassCommand))]
    [DependencyResolverBootstrapper(typeof(MEFContainerBootstrapper))]
    public class LecternBridgeTests : BaseTest
    {
        [Fact]
        public void TestRecieveMessage()
        {
            bridge.RecieveMessage(new LecternMessage("Hello Test!", bridge));
        }
    }
}
