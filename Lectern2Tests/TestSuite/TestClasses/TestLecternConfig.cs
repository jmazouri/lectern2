using System.ComponentModel.Composition;
using Lectern2.Configuration;

namespace Lectern2Tests.TestSuite.TestClasses
{
    [Export(typeof(LecternConfiguration))]
    public class TestLecternConfig : LecternConfiguration
    {
        public TestLecternConfig()
        {
            CommandPrefix = "/";
        }
    }
}
