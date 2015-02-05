using Lectern2.Bridges;
using Xunit;
using Xunit.Ioc;

namespace Lectern2Tests
{
    [RunWith(typeof(IocTestClassCommand))]
    [DependencyResolverBootstrapper(typeof(MEFContainerBootstrapper))]
    public class TestInjections : BaseTest
    {
        [Fact]
        public void TestBridgeInjection()
        {
            Assert.NotNull(bridge);
        }

        [Fact]
        public void TestConfigurationInjection()
        {
            Assert.NotNull(bridge.Configuration);
        }
    }
}
