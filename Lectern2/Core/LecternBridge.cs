using Lectern2.Interfaces;
using Lectern2.Messages;

namespace Lectern2.Core
{
    public abstract class LecternBridge : ILecternBridge
    {
        public Network Network { get; private set; }
        public abstract string Name { get; }
        public virtual bool Load(Network network)
        {
            Network = network;
            return true;
        }
        public abstract bool Connect();
        public abstract void Disconnect(string reason);
        public abstract void SendMessage(INetworkObject networkObject, LecternMessage message);

        protected bool CallEvent<TEvent>(TEvent eventData) where TEvent : Events.NetworkEvent
        {
            return Network.CallEvent(eventData);
        }
    }
}
