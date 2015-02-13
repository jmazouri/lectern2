using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lectern2.Interfaces;

namespace Lectern2
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
