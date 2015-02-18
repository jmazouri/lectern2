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
            LecternBridge bridge = GlobalContainer.Container.GetExport<LecternBridge>().Value;
            LecternMessage.LoadRegex();
            string input = Console.ReadLine();

            JsonConfiguration.Save<LecternConfiguration>(null);

            while (input != "quit")
            {
                Mediator.RecieveMessage(bridge, new LecternMessage(input));
                input = Console.ReadLine();
            }
        }

    }
}
