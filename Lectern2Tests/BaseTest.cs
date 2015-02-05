using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lectern2;
using Lectern2.Bridges;

namespace Lectern2Tests
{
    public class BaseTest
    {
        public ILecternBridge bridge { get; set; }

        public BaseTest()
        {
            //Init the container
            var d = PluginContainer.Container;
        }
    }
}
