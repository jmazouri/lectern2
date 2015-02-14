using Lectern2.Messages;

namespace Lectern2.Interfaces
{
    public interface ILecternPlugin
    {
        ILecternBridge Bridge { get; set; }
        string Name { get; }
        void Load();
        void Unload();
        string ReceiveMessage(LecternMessage message);
    }
}
