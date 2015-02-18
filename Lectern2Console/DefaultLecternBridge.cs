using System;
using Lectern2.Core;
using Lectern2.Interfaces;
using Lectern2.Messages;
using Lectern2.Util;

namespace Lectern2Console
{
    public class DefaultLecternBridge : LecternBridge
    {
        public override void Connect()
        {
            this.Log().Info("Default Lectern Bridge loaded.");
        }

        public override void SendMessage(LecternMessage message)
        {
            this.Log().Info("Message was sent via default bridge: {0}", message.MessageBody);
        }
    }
}
