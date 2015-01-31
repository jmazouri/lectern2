using Lectern2.Configuration;
using Lectern2.Plugins;

namespace Lectern2.Bridges
{
    public interface ILecternBridge
    {
        LecternConfiguration Configuration { get; set; }
        IPluginManager PluginManager { get; set; }
        void Connect();
        void SendMessage(LecternMessage message);
        void RecieveMessage(LecternMessage message);
    }
}
