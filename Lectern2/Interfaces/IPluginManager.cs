using System.Collections.Generic;

namespace Lectern2.Interfaces
{
    public interface IPluginManager
    {
        List<ILecternPlugin> LoadedPlugins { get; }
    }
}
