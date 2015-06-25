using System;
using Lectern2;
using Lectern2.Core;
using Lectern2.Interfaces;
using Lectern2.Messages;

namespace LecternCLI
{
    public class ConsoleBridge : LecternBridge
    {
        public override string Name
        {
            get { return "LecternCLI"; }
        }

        public ConsoleBridge()
        {
            LoggingExtensions.Logging.Log.InitializeWith<LoggingExtensions.NLog.NLogLog>();
            this.Log().Info("Console interface initializing...");
        }

        public override bool Load(Network network)
        {
            this.Log().Info("Console interface is ready.");
            return base.Load(network);
        }

        public override bool Connect()
        {
            this.Log().Info("Establishing virtual connection to the CLI...");
            Program.RegisterCLI(this);
            this.Log().Info("A virtual connection to the CLI has been established.");
            return true;
        }

        public override void Disconnect(string reason)
        {
            this.Log().Info("Disconnecting from the CLI...");
            Program.UnregisterCLI(this);
            this.Log().Warn("A virtual connection to the CLI has been terminated. (reason: {0})", reason);
        }

        public override void SendMessage(INetworkObject networkObject, LecternMessage message)
        {
            this.Log().Info(String.Format("{0}: {1}", networkObject.Name, message.MessageBody));
        }

        internal bool ConsoleInput(string input)
        {
            var message = new LecternMessage(input, Program.ConsoleLectern.Configuration);
            CallEvent(new Events.ReceiveMessage(this, message));
            return !message.IsCommand() || message.Command != "quit";
        }
    }
}
