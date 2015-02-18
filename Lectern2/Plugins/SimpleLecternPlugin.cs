using Lectern2.Core;
using Lectern2.Interfaces;
using Lectern2.Messages;

namespace Lectern2.Plugins
{
    public abstract class SimpleLecternPlugin : ILecternPlugin
    {
        public LecternBridge Bridge { get; set; }

        public string Name { get; private set; }

        protected SimpleLecternPlugin()
        {
            Name = GetType().Name;
        }

        public virtual void Load()
        {
            this.Log().Info("Plugin {0} was loaded.", Name);
        }

        public virtual void Unload()
        {
            this.Log().Info("Plugin {0} was unloaded.", Name);
        }

        public abstract void ReceiveMessage(LecternBridge bridge, LecternMessage message);

    }
}
