using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lectern2.Configuration;
using Lectern2.Plugins;
using Lectern2Tests.TestClasses;
using NLog;

namespace Lectern2.Bridges
{
    public class TestLecternBridge : ILecternBridge
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public LecternConfiguration Configuration { get; set; }

        public IPluginManager PluginManager { get; set; }

        public TestLecternBridge()
        {
            PluginManager = new TestPluginManager();
            Configuration = new TestLecternConfiguration();
        }

        public void Connect()
        {
            _logger.Info("TestBridge Connected");
        }

        public void SendMessage(LecternMessage message)
        {
            _logger.Info("Message was Sent: {0}", message.ToJson());
        }

        public void RecieveMessage(LecternMessage message)
        {
            _logger.Info("Message was Recieved: {0}", message.ToJson());
        }
    }
}
