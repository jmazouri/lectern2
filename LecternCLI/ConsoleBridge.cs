using System;
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
            Console.Out.WriteLine("Console interface initializing...");
        }

        public override bool Load(Network network)
        {
            Console.Out.WriteLine("Console interface is ready.");
            return base.Load(network);
        }

        public override bool Connect()
        {
            Console.Out.WriteLine("Establishing virtual connection to the CLI...");
            Program.RegisterCLI(this);
            Console.Out.WriteLine("A virtual connection to the CLI has been established.");
            return true;
        }

        public override void Disconnect(string reason)
        {
            Console.Out.WriteLine("Disconnecting from the CLI...");
            Program.UnregisterCLI(this);
            Console.Out.WriteLine("A virtual connection to the CLI has been terminated. (reason: {0})", reason);
        }

        public override void SendMessage(INetworkObject networkObject, LecternMessage message)
        {
            Console.Out.WriteLine("[{0}] {1}: {2}", DateTime.Now.ToShortTimeString(), networkObject.Name, message.MessageBody);
        }

        internal bool ConsoleInput(string input)
        {
            var message = new LecternMessage(input, Program.ConsoleLectern.Configuration);
            CallEvent(new Events.ReceiveMessage(this, message));
            return !message.IsCommand() || message.Command != "quit";
        }
    }
}
