using System;
using System.Collections.Generic;
using System.Linq;
using Lectern2.Interfaces;
using Lectern2.Messages;

namespace Lectern2.Core
{
    public class Mediator
    {
        private readonly List<ILecternBridge> _bridges = new List<ILecternBridge>();
        private readonly HashSet<Network> _networks = new HashSet<Network>();

        public Mediator()
        {
            _bridges.AddRange(GlobalContainer.Container.GetExportedValues<ILecternBridge>());

            foreach (var bridge in _bridges)
            {
                var network = new Network(
                    this,
                    new HashSet<ILecternPlugin>(GlobalContainer.Container.GetExportedValues<ILecternPlugin>()),
                    new HashSet<ILecternBridge> {bridge});

                if (network.Load())
                {
                    _networks.Add(network);
                }
                else
                {
                    this.Log().Error("A network has failed to load due to incomplete initialization!");
                    network.Unload("Network initialization failure");
                }
            }

            foreach (var network in _networks.Where(network => !network.Connect()))
            {
                this.Log().Error("A network has failed to load due to incomplete connections!");
                network.Unload("Network connection failure");
            }
        }

        public void BroadcastEvent<T>(T eventData) where T : Events.NetworkEvent
        {
            foreach (var network in _networks)
            {
                network.CallEvent(eventData);
            }
        }

        public void BroadcastMessage(LecternMessage message)
        {
            foreach (var network in _networks)
            {
                network.SendMessage(NetworkSystem, message);
            }
        }

        internal LecternSystem NetworkSystem
        {
            get
            {
                return new LecternSystem(this, _networks.ToList());
            }
        }

        //TODO: Is there a better way!?
        internal class LecternSystem: Network, INetworkObject
        {
            public Network Network { get { return this; } }
            private readonly List<Network> _systemNetworks;

            public string Name { get { return "Lectern System"; } }

            public LecternSystem(Mediator mediator, List<Network> systemNetworks)
                : base(
                    mediator,
                    new HashSet<ILecternPlugin>(systemNetworks.SelectMany(network => network.Plugins).Distinct()),
                    new HashSet<ILecternBridge>(systemNetworks.SelectMany(network => network.Bridges).Distinct()))
            {
                _systemNetworks = systemNetworks;
                Load(this);
            }

            public bool Load(Network network)
            {
                return true;
            }

            internal new bool CallEvent<TEvent>(TEvent eventData) where TEvent : Events.NetworkEvent
            {
                return _systemNetworks.Count(systemNetwork => systemNetwork.CallEvent(eventData)) > 0;
            }

            public new bool SetCallback<TEvent>(ILecternPlugin plugin, Action<Events.NetworkEvent> callback) where TEvent : Events.NetworkEvent
            {
                throw new InvalidOperationException("Callbacks can't and shouldn't be set from the Lectern System scope.");
            }

            public void SendMessage(LecternMessage message)
            {
                SendMessage(this, message);
            }

            public new void SendMessage(INetworkObject sender, LecternMessage message)
            {
                foreach (var systemNetwork in _systemNetworks)
                {
                    systemNetwork.SendMessage(sender, message);
                }
            }
        }
    }
}
