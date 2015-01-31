using System.Collections.Generic;

namespace Lectern2.Plugins
{
    public interface IPluginManager
    {
        List<ILecternPlugin> LoadedPlugins { get; }
    }
}
