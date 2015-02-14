using System.Collections.Generic;
using Lectern2;
using Lectern2Tests.TestClasses;
using Xunit;
using Xunit.Extensions;

namespace Lectern2Tests
{
    public class LecternMessageTests : BaseTest
    {
        [Theory]
        [MemberData("TestArgumentData")]
        public void TestArguments(string messagetext, List<string> expected )
        {
            var message = new LecternMessage(messagetext, new TestLecternConfig());
            Assert.Equal(expected, message.Arguments);
        }

        public static IEnumerable<object[]> TestArgumentData
        {
            get
            {
                return new[]
                {
                    new object[] { "/ln one two three", new List<string> { "ln", "one", "two", "three" } },
                    new object[] { "/ln kick \"Offensive Name\"", new List<string> { "ln", "kick", "Offensive Name" } },
                    new object[] { "/ln weird", new List<string> { "ln", "weird" } },
                    new object[] { "hello world!", new List<string> { "hello", "world!"}}
                };
            }
        }
    }
}
