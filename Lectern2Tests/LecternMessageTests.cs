using System.Collections.Generic;
using Lectern2;
using Lectern2.Bridges;
using Lectern2Tests.TestClasses;
using Ninject;
using Xunit;

namespace Lectern2Tests
{
    public class LecternMessageTests
    {
        public ILecternBridge bridge = PluginContainer.Kernel.Get<TestLecternBridge>();

        [Theory, MemberData("TestArgumentData")]
        public void TestArguments(string messagetext, List<string> expected )
        {
            var message = new LecternMessage(messagetext, bridge);

            Assert.Equal(expected, message.Arguments);
        }

        [Theory, MemberData("TestSerializationData")]
        public void TestSerialization(string messagetext, string expected)
        {
            var message = new LecternMessage(messagetext, bridge);
            Assert.Equal(expected, message.ToJson(false));
        }

        public static IEnumerable<object[]> TestSerializationData
        {
            get
            {
                return new[]
                {
                    new object[] { "/ln one two three", "{\"MessageBody\":\"/ln one two three\",\"Arguments\":[\"one\",\"two\",\"three\"]}" },
                    new object[] { "/ln kick \"Offensive Name\"", "{\"MessageBody\":\"/ln kick \\\"Offensive Name\\\"\",\"Arguments\":[\"kick\",\"Offensive Name\"]}" },
                };
            }
        }

        public static IEnumerable<object[]> TestArgumentData
        {
            get
            {
                return new[]
                {
                    new object[] { "/ln one two three", new List<string> { "one", "two", "three" } },
                    new object[] { "/ln kick \"Offensive Name\"", new List<string> { "kick", "Offensive Name" } },
                    new object[] { "/ln weird", new List<string> { "weird" } }
                };
            }
        }
    }
}
