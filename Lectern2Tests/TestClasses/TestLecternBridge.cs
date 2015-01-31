using Lectern2;
using Lectern2.Bridges;
using Lectern2.Configuration;
using Lectern2.Plugins;
using NLog;

namespace Lectern2Tests.TestClasses
{
    public class TestLecternBridge : ILecternBridge
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public LecternConfiguration Configuration { get; set; }

        public IPluginManager PluginManager { get; set; }

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
