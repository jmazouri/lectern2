using Lectern2.Interfaces;
using Lectern2.Messages;

namespace Lectern2.Core
{
    public static class Events
    {
        public abstract class NetworkEvent
        {
            private readonly INetworkObject _sender;

            protected NetworkEvent(INetworkObject sender)
            {
                _sender = sender;
            }

            public INetworkObject Sender
            {
                get { return _sender; }
            }
        }

        public class SendMessage : NetworkEvent
        {
            public LecternMessage Message { get; private set; }

            public SendMessage(INetworkObject sender, LecternMessage message) : base(sender)
            {
                Message = message;
            }
        }

        public class ReceiveMessage : NetworkEvent
        {
            public LecternMessage Message { get; private set; }

            public ReceiveMessage(INetworkObject sender, LecternMessage message) : base(sender)
            {
                Message = message;
            }
        }
    }
}
