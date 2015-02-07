using Lectern2.Configuration;

namespace Lectern2.Interfaces
{
    public interface ILecternBridge
    {
        IPluginManager PluginManager { get; set; }
        void Connect();
        void SendMessage(LecternMessage message);
        void RecieveMessage(LecternMessage message);
    }
}
