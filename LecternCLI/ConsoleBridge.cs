using System;
using Lectern2.Core;
using Lectern2.Interfaces;
using Lectern2.Messages;

namespace LecternCLI
{
    public class ConsoleBridge : ILecternBridge
    {
        public Network Network { get; private set; }

        public string Name
        {
            get { throw new NotImplementedException(); }
        }

        public ConsoleBridge()
        {
            Console.Out.WriteLine("Console interface initializing...");
        }

        public bool Load(Network network)
        {
            Network = network;
            return true;
        }

        public void Connect()
        {
            throw new NotImplementedException();
        }

        public void SendMessage(INetworkObject networkObject, LecternMessage message)
        {
            throw new NotImplementedException();
        }

        public void ReceiveMessage(LecternMessage message)
        {
            Console.Out.WriteLine("[{0}] {1}", DateTime.Now.ToShortTimeString(), message.MessageBody);
        }
    }
}
