using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lectern2.Bridges;

namespace Lectern2.Plugins
{
    public abstract class SimpleLecternPlugin : ILecternPlugin
    {
        public ILecternBridge CurrentBridge;
        public string Name { get; private set; }

        public abstract void RecieveMessage(LecternMessage message);

        protected SimpleLecternPlugin()
        {
            Name = GetType().Name;
        }
    }
}
