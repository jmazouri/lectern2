using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lectern2.Configuration;

namespace Lectern2Tests.TestClasses
{
    public class TestLecternConfig : LecternConfiguration
    {
        public TestLecternConfig()
        {
            CommandPrefix = "/";
        }
    }
}
