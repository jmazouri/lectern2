using Lectern2.Configuration;

namespace Lectern2.Interfaces
{
    public interface ILecternBridge
    {
        void Connect();
        void SendMessage(LecternMessage message);
        void ReceiveMessage(LecternMessage message);
    }
}
