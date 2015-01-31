using System.Linq;
using Lectern2.Plugins;
using Lectern2Tests.TestClasses;
using Xunit;

namespace Lectern2Tests
{
    public class PluginManagerTests
    {
        [Fact]
        public void TestPluginLoading()
        {
            TestPluginManager man = new TestPluginManager();
            Assert.True(man.LoadedPlugins.Any());
            Assert.True(man.LoadedPlugins.Any(d => d.Name == "TestLecternPlugin"));
        }

        [Fact]
        public void TestRealPluginLoading()
        {
            DefaultPluginManager man = new DefaultPluginManager();
            Assert.True(man.LoadedPlugins.Any(), "No plugins were found.");
            Assert.True(man.LoadedPlugins.Any(d => d.Name == "MiscTools"), "The default MiscTools plugin wasn't found.");

            man.LoadedPlugins.First().Load();
        }

        
    }
}
