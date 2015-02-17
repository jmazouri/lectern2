using System.ComponentModel.Composition;
using Lectern2.Interfaces;
using Lectern2.Messages;
using Lectern2.Plugins;
using Lectern2.Util;

namespace Lectern2Tests.TestSuite.TestClasses
{
    [Export(typeof(ILecternPlugin))]
    public class TestLecternPlugin : SimpleLecternPlugin
    {
        public override string ReceiveMessage(LecternMessage message)
        {
            logger.Info("Message was Received by plugin {0}: {1}", Name, JsonUtil.ToJson(message, false));
            return "It works.";
        }

    }
}
