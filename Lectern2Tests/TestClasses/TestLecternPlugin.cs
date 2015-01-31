using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lectern2;
using Lectern2.Plugins;
using NLog;

namespace Lectern2Tests.TestClasses
{
    public class TestLecternPlugin : SimpleLecternPlugin
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public override void RecieveMessage(LecternMessage message)
        {
            _logger.Info("Message was Recieved by plugin {0}: {1}", Name, message.ToJson());
        }
    }
}
