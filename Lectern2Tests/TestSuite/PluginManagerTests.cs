using System.Linq;
using Lectern2.Interfaces;
using Lectern2.Plugins;
using Xunit;

namespace Lectern2Tests.TestSuite
{

    public class PluginManagerTests : BaseTest
    {
        [Fact]
        public void TestPluginLoading()
        {
            var man = new DefaultPluginManager();
            Assert.True(man.LoadedPlugins.Any(), "No plugins were found.");
            Assert.True(man.LoadedPlugins.Any(d => d.Name == "MiscTools"), "The default MiscTools plugin wasn't found.");

            foreach (ILecternPlugin plugin in man.LoadedPlugins)
            {
                plugin.Load();
            }
        }

        
    }
}
