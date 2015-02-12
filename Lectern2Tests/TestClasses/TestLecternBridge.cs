using System;
using System.ComponentModel.Composition;
using Lectern2;
using Lectern2.Configuration;
using Lectern2.Interfaces;
using Lectern2.Plugins;
using NLog;
using Xunit;

namespace Lectern2Tests.TestClasses
{
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
            _logger.Info("Message was Sent: {0}", message.ToJson());
        }

        public void ReceiveMessage(LecternMessage message)
        {
            _logger.Info("Message was Recieved: {0}", message.ToJson());
        }
    }
}
