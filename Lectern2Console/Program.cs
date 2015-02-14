using System;
using Lectern2.Configuration;
using Lectern2.Core;
using Lectern2.Interfaces;
using Lectern2.Messages;
using LoggingExtensions.Logging;
using LoggingExtensions.NLog;

namespace Lectern2Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.InitializeWith<NLogLog>();
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
