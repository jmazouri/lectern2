using System;
using System.Collections.Generic;
using System.Linq;
using Lectern2.Interfaces;
using Lectern2.Messages;

namespace Lectern2.Core
{
    public static class Mediator
    {
        private static List<ILecternBridge> _registeredBridges = new List<ILecternBridge>();
        public static IPluginManager PluginManager { get; private set; }

        public static void RecieveMessage(ILecternBridge bridge, LecternMessage message)
        {
            foreach (ILecternPlugin plugin in PluginManager.LoadedPlugins)
            {
                
            }
        }
    }
}
