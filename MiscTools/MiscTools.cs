using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Lectern2;
using Lectern2.Core;
using Lectern2.Messages;
using Lectern2.Plugins;

namespace MiscTools
{
    public class MiscTools : SimpleLecternPlugin
    {
        public override void Load()
        {
            this.Log().Info("Hello from MiscTools!");
        }

        public override void ReceiveMessage(LecternBridge bridge, LecternMessage message)
        {
            if (message.Arguments.FirstOrDefault() == "info")
            {
                StringBuilder systemInfo = new StringBuilder();
                systemInfo.Append("Lectern2 | ");
                systemInfo.Append(String.Format("OS Version: {0} | ", Environment.OSVersion.VersionString));
                systemInfo.Append(String.Format("Used Memory: {0:F}mb | ", (Process.GetCurrentProcess().PrivateMemorySize64 / 1000000)));

                /*
                systemInfo.Append(String.Format("Plugins Loaded: {0}", GlobalContainer.Container.GetExport<ILecternBridge>().Value.
                    PluginManager.LoadedPlugins.Select(d=>d.Name).Aggregate((cur, next) => cur + ", "+ next)));
                */

                Mediator.SendMessage(bridge, new LecternMessage(systemInfo.ToString()));
            }
        }
    }
}
