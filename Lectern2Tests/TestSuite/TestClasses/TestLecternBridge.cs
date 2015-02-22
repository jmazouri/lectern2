using System.ComponentModel.Composition;
using Lectern2.Core;
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

        public Network Network { get; private set; }

        public string Name { get { return "TestBridge"; } }

        public TestLecternBridge()
        {
            this.Log().Info("Test Bridge created with null values");
        }

        public bool Load(Network network)
        {
            Network = network;
            return true;
        }

        public bool Connect()
        {
            _logger.Info("TestBridge Connected");
            return true;
        }

        public void SendMessage(INetworkObject networkObject, LecternMessage message)
        {
            _logger.Info("Message was Sent: {0}", JsonUtil.ToJson(message));
        }

        public void Disconnect(string reason)
        {
            _logger.Info("TestBridge Disconnected ({0})", reason);
        }

        public void ReceiveMessage(LecternMessage message)
        {
            _logger.Info("Message was Received: {0}", JsonUtil.ToJson(message));
        }
    }
}
