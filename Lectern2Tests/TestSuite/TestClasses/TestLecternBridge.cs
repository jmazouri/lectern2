using System.ComponentModel.Composition;
using Lectern2.Interfaces;
using Lectern2.Messages;
using Lectern2.Util;
using NLog;

namespace Lectern2Tests.TestSuite.TestClasses
{
    // ReSharper disable once UnusedMember.Global
    [Export(typeof(ILecternBridge))]
    public class TestLecternBridge : ILecternBridge
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public IPluginManager PluginManager { get; set; }

        public void Connect()
        {
            _logger.Info("TestBridge Connected");
        }

        public void SendMessage(LecternMessage message)
        {
            _logger.Info("Message was Sent: {0}", JsonUtil.ToJson(message));
        }

        public void ReceiveMessage(LecternMessage message)
        {
            _logger.Info("Message was Received: {0}", JsonUtil.ToJson(message));
        }
    }
}
