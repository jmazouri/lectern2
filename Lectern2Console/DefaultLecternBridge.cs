using System;
using Lectern2.Core;
using Lectern2.Interfaces;
using Lectern2.Messages;

namespace Lectern2Console
{
    public class ConsoleBridge : ILecternBridge
    {
        public void Connect()
        {
            throw new NotImplementedException();
        }

        public void SendMessage(LecternMessage message)
        {
            throw new NotImplementedException();
        }

        public void ReceiveMessage(LecternMessage message)
        {
            /*
            foreach (ILecternPlugin plugin in PluginManager.LoadedPlugins)
            {
                string ret = plugin.ReceiveMessage(message);

                if (ret == null)
                {
                    continue;
                }

                this.Log().Info("[{0}] {1}", plugin.Name, ret);
                break;
            }
            */
        }

        public Network Network
        {
            get { throw new NotImplementedException(); }
        }

        public string Name
        {
            get { throw new NotImplementedException(); }
        }
    }
}
