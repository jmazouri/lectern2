using System;
using System.Collections.Generic;
using System.Linq;
using Lectern2.Interfaces;
using Lectern2.Messages;

namespace Lectern2.Core
{
    public class Network
    {
        internal ISet<ILecternPlugin> Plugins { get; private set; }
        internal ISet<ILecternBridge> Bridges { get; private set; }

        private readonly Dictionary<Type, Dictionary<ILecternPlugin, Action<Events.NetworkEvent>>> _callbackDictionary;
        private readonly Mediator _mediator;

        public Network(Mediator mediator, ISet<ILecternPlugin> plugins, ISet<ILecternBridge> bridges)
        {
            _mediator = mediator;
            Plugins = plugins;
            Bridges = bridges;
            _callbackDictionary = new Dictionary<Type, Dictionary<ILecternPlugin, Action<Events.NetworkEvent>>>();
        }

        internal bool CallEvent<TEvent>(TEvent eventData) where TEvent : Events.NetworkEvent
        {
            Dictionary<ILecternPlugin, Action<Events.NetworkEvent>> eventCallbacks;
            if (!_callbackDictionary.TryGetValue(typeof(TEvent), out eventCallbacks))
            {
                return false;
            }
            foreach (var eventCallback in eventCallbacks)
            {
                eventCallback.Value.Invoke(eventData);
            }
            return true;
        }

        public bool SetCallback<TEvent>(ILecternPlugin plugin, Action<Events.NetworkEvent> callback) where TEvent : Events.NetworkEvent
        {
            Dictionary<ILecternPlugin, Action<Events.NetworkEvent>> eventCallbacks;
            if (!_callbackDictionary.TryGetValue(typeof (TEvent), out eventCallbacks))
            {
                eventCallbacks = new Dictionary<ILecternPlugin, Action<Events.NetworkEvent>>();
                _callbackDictionary.Add(typeof(TEvent), eventCallbacks);
            }
            else
            {
                if (eventCallbacks.ContainsKey(plugin))
                {
                    this.Log()
                        .Error("Plugin {0} attempted to set a callback for event {1}, but a callback is already set!",
                            plugin.Name, typeof(TEvent).Name);
                    return false;
                }
            }
            
            eventCallbacks.Add(plugin, callback);
            return true;
        }

        public void SendMessage(INetworkObject sender, LecternMessage message)
        {
            foreach (var lecternBridge in Bridges)
            {
                lecternBridge.SendMessage(sender, message);
            }
        }
    }
}
