using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Lectern2.Messages;
using Lectern2.Plugins;

namespace MiscTools
{
    public class MiscTools : SimpleLecternPlugin
    {
        protected override void ReceiveMessage(LecternMessage message)
        {
            if (!message.IsCommand || message.Command != "info") return;

            var systemInfo = new StringBuilder();
                systemInfo.Append("Lectern2 | ");
                systemInfo.Append(String.Format("OS Version: {0} | ", Environment.OSVersion.VersionString));
                systemInfo.Append(String.Format("Used Memory: {0:F}mb | ", (Process.GetCurrentProcess().PrivateMemorySize64 / 1000000)));
            SendMessage(systemInfo.ToString());
        }
    }
}
