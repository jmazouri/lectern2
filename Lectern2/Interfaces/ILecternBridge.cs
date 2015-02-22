using Lectern2.Core;
using Lectern2.Messages;

namespace Lectern2.Interfaces
{
    public interface ILecternBridge : INetworkObject
    {
        void Connect();
        void SendMessage(INetworkObject networkObject, LecternMessage message);
        void ReceiveMessage(LecternMessage message);
    }
}
