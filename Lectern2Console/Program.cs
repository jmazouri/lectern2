using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Lectern2;
using Lectern2.Configuration;
using Lectern2.Interfaces;

namespace Lectern2Console
{
    class Program
    {
        static void Main(string[] args)
        {
            LoggingExtensions.Logging.Log.InitializeWith<LoggingExtensions.NLog.NLogLog>();
            ILecternBridge bridge = GlobalContainer.Container.GetExport<ILecternBridge>().Value;
            LecternMessage.LoadRegex();
            string input = Console.ReadLine();

            JsonConfiguration.Save<LecternConfiguration>(null);

            while (input != "quit")
            {
                bridge.ReceiveMessage(new LecternMessage(input));
                input = Console.ReadLine();
            }
        }

    }
}
