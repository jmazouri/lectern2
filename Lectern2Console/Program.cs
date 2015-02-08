using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Lectern2;
using Lectern2.Interfaces;

namespace Lectern2Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ILecternBridge bridge = GlobalContainer.Container.GetExport<ILecternBridge>().Value;
            LecternMessage.LoadRegex();
            string input = Console.ReadLine();

            while (input != "quit")
            {
                bridge.RecieveMessage(new LecternMessage(input));
                input = Console.ReadLine();
            }
        }

    }
}
