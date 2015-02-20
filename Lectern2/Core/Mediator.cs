using System;
using System.Collections.Generic;
using System.Linq;
using Lectern2.Interfaces;
using Lectern2.Messages;
using Lectern2.Plugins;

namespace Lectern2.Core
{
    public static class Mediator
    {
        private static List<LecternBridge> _registeredBridges = new List<LecternBridge>();
        private static readonly IPluginManager PluginManager = new DefaultPluginManager();

        public static void RecieveMessage(LecternBridge bridge, LecternMessage message)
        {
            foreach (var plugin in PluginManager.LoadedPlugins)
            {
                plugin.ReceiveMessage(bridge, message);
            }
        }
    }
}
