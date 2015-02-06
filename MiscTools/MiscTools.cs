using Lectern2;
using Lectern2.Plugins;

namespace MiscTools
{
    public class MiscTools : SimpleLecternPlugin
    {
        public override void Load()
        {
            logger.Info("Hello from MiscTools!");
            logger.Info("Did the injection work? {0}", (Bridge == null ? "no...": "YES!!"));
        }

        public override void RecieveMessage(LecternMessage message)
        {
            
        }
    }
}
