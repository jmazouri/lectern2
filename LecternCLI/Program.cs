using System;
using System.Collections.Generic;
using System.Linq;
using Lectern2.Core;
using Lectern2.Interfaces;

namespace LecternCLI
{
    static class Program
    {
        internal static Lectern ConsoleLectern;
        private static List<ConsoleBridge> _cliBridges = new List<ConsoleBridge>();

        static void Main()
        {
            ConsoleLectern = new Lectern(additionalBridges: new HashSet<ILecternBridge> {new ConsoleBridge()});
            //( ͡° ͜ʖ ͡°)
            bool quit;

            do
            {
                var message = Console.In.ReadLine();
                quit = !_cliBridges.All(consoleBridge => consoleBridge.ConsoleInput(message));
            } while (!quit);
        }

        internal static void RegisterCLI(ConsoleBridge bridge)
        {
            _cliBridges.Add(bridge);
        }

        internal static void UnregisterCLI(ConsoleBridge bridge)
        {
            _cliBridges.Remove(bridge);
        }
    }
}
