using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lectern2;
using Lectern2.Bridges;
using Lectern2Tests.TestClasses;

namespace Lectern2Tests
{
    public class BaseTest
    {
        public ILecternBridge bridge { get; set; }

        public BaseTest()
        {
            bridge = new TestLecternBridge();
        }
    }
}
