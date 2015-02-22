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
