using System.Collections.Generic;
using Lectern2.Interfaces;

namespace Lectern2Tests.TestSuite.TestClasses
{
    // ReSharper disable once UnusedMember.Global
    public class TestPluginManager : IPluginManager
    {
        public TestPluginManager()
        {
            LoadedPlugins = new List<ILecternPlugin> { new TestLecternPlugin() };
        }

        public List<ILecternPlugin> LoadedPlugins { get; private set; }
    }
}
