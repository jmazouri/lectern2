using System.IO;
using Lectern2.Configuration;
using Xunit;

namespace Lectern2Tests.TestSuite
{
    public class LecternConfigurationTests
    {
        private static void ClearTestFiles()
        {
            if (File.Exists(JsonConfigParser.GetPathForConfig<LecternConfiguration>()))
            {
                File.Delete(JsonConfigParser.GetPathForConfig<LecternConfiguration>());
            }

            JsonConfigParser.ForceClearCache();
        }

        [Fact]
        public void TestConfigSections()
        {
            var test1Config = new LecternConfiguration
            {
                BotName = "Test 1 Bot",
                CommandPrefix = "!"
            };

            JsonConfigParser.Save(test1Config, "test1");

            var test1ConfigLoaded = JsonConfigParser.Load<LecternConfiguration>("test1");
            Assert.Equal(test1ConfigLoaded.BotName, test1Config.BotName);
            Assert.Equal(test1ConfigLoaded.CommandPrefix, test1Config.CommandPrefix);

            var test2Config = new LecternConfiguration
            {
                BotName = "Should be default",
                CommandPrefix = "#"
            };

            JsonConfigParser.Save(test2Config);

            var test2ConfigLoaded = JsonConfigParser.Load<LecternConfiguration>();
            Assert.Equal(test2ConfigLoaded.BotName, test2Config.BotName);
            Assert.Equal(test2ConfigLoaded.CommandPrefix, test2Config.CommandPrefix);

            ClearTestFiles();
        }

        [Fact]
        public void TestConfigSaving()
        {
            var test1Config = new LecternConfiguration
            {
                BotName = "Test 1 Bot",
                CommandPrefix = "!"
            };

            JsonConfigParser.Save(test1Config, "test1");

            Assert.True(File.Exists(JsonConfigParser.GetPathForConfig<LecternConfiguration>()));
            var fileContent = File.ReadAllText(JsonConfigParser.GetPathForConfig<LecternConfiguration>());
            Assert.Equal(fileContent, "{\"test1\":{\"Plugins\":[],\"BotName\":\"Test 1 Bot\",\"CommandPrefix\":\"!\"}}");

            ClearTestFiles();
        }
        
    }
}
