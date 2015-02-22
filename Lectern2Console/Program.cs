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
            LecternMessage.LoadRegex();
            string input = Console.ReadLine();

            while (input != "quit")
            {
                input = Console.ReadLine();
            }
        }

    }
}
