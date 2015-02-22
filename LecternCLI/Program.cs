using System.Collections.Generic;
using Lectern2.Core;
using Lectern2.Interfaces;

namespace LecternCLI
{
    static class Program
    {
        private static Lectern _consoleLectern;
        static void Main()
        {
            _consoleLectern = new Lectern(additionalBridges: new HashSet<ILecternBridge> {new ConsoleBridge()});
            //( ͡° ͜ʖ ͡°)
        }
    }
}
