using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lectern2.Core;
using Lectern2.Interfaces;
using Lectern2.Messages;

namespace Lectern2.Bridges.Telegram
{
    public class TelegramBridge : LecternBridge
    {
        public override string Name
        {
            get { return "TelegramBridge"; }
        }

        public override bool Connect()
        {
            this.Log().Info("Hello from TelegramBridge!");
            return true;
        }

        public override void SendMessage(INetworkObject networkObject, LecternMessage message)
        {
            this.Log().Info("Telegram got a message! "+message.MessageBody);
        }

        public override void Disconnect(string reason)
        {
            this.Log().Info("Telegram says bye :(");
        }
    }
}
