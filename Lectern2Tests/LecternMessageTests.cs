using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lectern2;
using Lectern2.Bridges;
using Lectern2.Plugins;
using Ninject;
using Xunit;

namespace Lectern2Tests
{
    public class LecternMessageTests
    {
        [Fact]
        public void TestArguments()
        {
            var kernel = DefaultPluginManager.CreateKernel();
            var message = new LecternMessage("/ln one two three", kernel.Get<TestLecternBridge>());

            Assert.Equal(message.Arguments, new List<string> { "one", "two", "three" });
        }
    }
}
