using Lectern2.Interfaces;
using Lectern2.Messages;
using NLog;

namespace Lectern2.Plugins
{
    public abstract class SimpleLecternPlugin : ILecternPlugin
    {
        protected Logger logger = LogManager.GetCurrentClassLogger();

        public ILecternBridge Bridge { get; set; }

        public string Name { get; private set; }

        protected SimpleLecternPlugin()
        {
            Name = GetType().Name;
        }

        public virtual void Load()
        {
            logger.Info("Plugin {0} was loaded.", Name);
        }

        public virtual void Unload()
        {
            logger.Info("Plugin {0} was unloaded.", Name);
        }

        public abstract string ReceiveMessage(LecternMessage message);

    }
}
