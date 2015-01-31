using System.Collections.Generic;
using System.Linq;
using Ninject;

namespace Lectern2.Plugins
{
    public class DefaultPluginManager : IPluginManager
    {
        public List<ILecternPlugin> LoadedPlugins
        {
            get
            {
                var Kernel = PluginContainer.Kernel;
                return Kernel.GetAll<ILecternPlugin>().ToList();
            }
        }
    }
}
