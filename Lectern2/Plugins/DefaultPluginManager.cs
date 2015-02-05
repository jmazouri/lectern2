using System.Collections.Generic;
using System.Linq;

namespace Lectern2.Plugins
{
    public class DefaultPluginManager : IPluginManager
    {
        public List<ILecternPlugin> LoadedPlugins
        {
            get
            {
                return PluginContainer.Container.GetExports<ILecternPlugin>().Select(d=>d.Value).ToList();
            }
        }
    }
}
