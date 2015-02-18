using Lectern2.Core;
using Lectern2.Messages;

namespace Lectern2.Core
{
    public abstract class LecternBridge
    {
        public abstract void Connect();

        /// <summary>
        /// Recieves a message to the bridge.
        /// </summary>
        /// <param name="bridge"></param>
        /// <param name="message"></param>
        public virtual void RecieveMessage(LecternMessage message)
        {
            Mediator.RecieveMessage(this, message);
        }

        /// <summary>
        /// Sends a message via the protocol that the bridge uses.
        /// </summary>
        /// <param name="bridge">The bridge to send via.</param>
        /// <param name="message"></param>
        public abstract void SendMessage(LecternMessage message);
    }
}
