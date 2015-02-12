using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lectern2;
using Lectern2.Interfaces;
using NLog;

namespace Lectern2Console
{
    public class DefaultLecternBridge : ILecternBridge
    {
        public IPluginManager PluginManager { get; set; }

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
            foreach (ILecternPlugin plugin in PluginManager.LoadedPlugins)
            {
                string ret = plugin.RecieveMessage(message);

                if (ret == null)
                {
                    continue;
                }

                this.Log().Info("[{0}] {1}", plugin.Name, ret);
                break;
            }
        }
    }
}
