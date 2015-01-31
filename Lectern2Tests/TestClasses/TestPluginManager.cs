using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lectern2;
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
