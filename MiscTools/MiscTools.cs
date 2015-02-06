using Lectern2;
using Lectern2.Bridges;
using Lectern2.Plugins;

namespace MiscTools
{
    public class MiscTools : SimpleLecternPlugin
    {
        public override void Load()
        {
            logger.Info("Hello from MiscTools!");
        }

        public override void RecieveMessage(LecternMessage message)
        {
            
        }
    }
}
