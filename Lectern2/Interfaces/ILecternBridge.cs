using Lectern2.Messages;

namespace Lectern2.Interfaces
{
    public interface ILecternBridge : INetworkObject
    {
        bool Connect();
        void SendMessage(INetworkObject networkObject, LecternMessage message);
        void Disconnect(string reason);
    }
}
