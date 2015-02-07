using System.Collections.Generic;
using System.Linq;
using Lectern2.Interfaces;

namespace Lectern2.Plugins
{
    public class DefaultPluginManager : IPluginManager
    {
        public List<ILecternPlugin> LoadedPlugins
        {
            get
            {
                return GlobalContainer.Container.GetExports<ILecternPlugin>().Select(d=>d.Value).ToList();
            }
        }
    }
}
