using System.Collections.Generic;
using Lectern2.Interfaces;

namespace Lectern2.Core
{
    public class Mediator
    {
        private List<ILecternBridge> _registeredBridges = new List<ILecternBridge>();
        public IPluginManager PluginManager { get; private set; }

        public Mediator()
        {
            
        }
    }
}
