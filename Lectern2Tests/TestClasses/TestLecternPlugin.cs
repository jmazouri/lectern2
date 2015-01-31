using Lectern2;
using Lectern2.Plugins;

namespace Lectern2Tests.TestClasses
{
    public class TestLecternPlugin : SimpleLecternPlugin
    {
        public override void RecieveMessage(LecternMessage message)
        {
            logger.Info("Message was Recieved by plugin {0}: {1}", Name, message.ToJson());
        }
    }
}
