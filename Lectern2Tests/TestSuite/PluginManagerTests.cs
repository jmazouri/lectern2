using System.Linq;
using Lectern2.Core;
using Lectern2.Interfaces;
using Lectern2.Plugins;
using Xunit;

namespace Lectern2Tests.TestSuite
{

    public class PluginManagerTests : BaseTest
    {
        private readonly Lectern _lectern;
        public PluginManagerTests(ContainerFixture fixture)
        {
            _lectern = fixture.TestLectern;
        }

        [Fact]
        public void TestAssemblyLoading()
        {
            Assert.True(_lectern.Mediator.NetworkSystem.Plugins.Any(), "No plugins were found.");
            Assert.True(_lectern.Mediator.NetworkSystem.Plugins.Any(d => d.Name == "MiscTools"), "The MiscTools plugin wasn't found.");
        }
    }
}
