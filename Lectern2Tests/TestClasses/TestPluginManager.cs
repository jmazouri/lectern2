using System.Collections.Generic;
using Lectern2.Interfaces;
using Lectern2.Plugins;

namespace Lectern2Tests.TestClasses
{
    public class TestPluginManager : IPluginManager
    {
        public TestPluginManager()
        {
            LoadedPlugins = new List<ILecternPlugin> { new TestLecternPlugin() };
        }

        public List<ILecternPlugin> LoadedPlugins { get; private set; }
    }
}
