using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lectern2.Plugins
{
    public interface IPluginManager
    {
        List<ILecternPlugin> LoadedPlugins { get; }
    }
}
