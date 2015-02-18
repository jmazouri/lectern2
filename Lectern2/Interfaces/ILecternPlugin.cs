using Lectern2.Core;
using Lectern2.Messages;

namespace Lectern2.Interfaces
{
    public interface ILecternPlugin
    {
        string Name { get; }
        void Load();
        void Unload();
        void ReceiveMessage(LecternBridge bridge, LecternMessage message);
    }
}
