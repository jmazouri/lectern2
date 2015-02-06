using Lectern2.Bridges;
using NLog;

namespace Lectern2.Plugins
{
    public abstract class SimpleLecternPlugin : ILecternPlugin
    {
        protected Logger logger = LogManager.GetCurrentClassLogger();

        public ILecternBridge Bridge { get; set; }

        public string Name { get; private set; }

        public virtual void Load()
        {
            logger.Info("Plugin {0} was loaded.", Name);
        }

        public virtual void Unload()
        {
            logger.Info("Plugin {0} was unloaded.", Name);
        }

        public abstract void RecieveMessage(LecternMessage message);

        protected SimpleLecternPlugin()
        {
            Name = GetType().Name;
        }
    }
}
