using System;
using Lectern2.Core;
using Lectern2.Interfaces;
using Lectern2.Messages;

namespace Lectern2.Plugins
{
    public abstract class SimpleLecternPlugin : ILecternPlugin
    {
        public string Name { get; protected set; }
        public Network Network { get; private set; }

        protected SimpleLecternPlugin()
        {
            Name = GetType().Name;
        }

        public virtual bool Load(Network network)
        {
            Network = network;
            this.Log().Info("Plugin {0} was loaded.", Name);
            SetCallback<Events.ReceiveMessage>(_receiveMessage);
            return true;
        }

        public virtual void Unload()
        {
            this.Log().Info("Plugin {0} was unloaded.", Name);
        }

        protected bool SetCallback<TEvent>(Action<Events.NetworkEvent> callback) where TEvent : Events.NetworkEvent
        {
            return Network.SetCallback<TEvent>(this, callback);
        }

        private void _receiveMessage(Events.NetworkEvent eventData)
        {
            var messageData = eventData as Events.ReceiveMessage;
            ReceiveMessage(messageData.Message);
        }

        protected abstract void ReceiveMessage(LecternMessage message);

        protected virtual void SendMessage(LecternMessage message)
        {
            Network.SendMessage(this, message);
        }

    }
}
