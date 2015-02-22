using Lectern2.Core;
using Lectern2.Interfaces;
using Lectern2.Messages;
using Xunit;

namespace Lectern2Tests.TestSuite
{
    [Collection("LecternTestSuite")]
    public class BaseTest
    {
        protected BaseTest()
        {
            LecternMessage.LoadRegex();
        }
    }
}
