using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Lectern2.Configuration;
using Xunit;

namespace Lectern2Tests
{
    public class LecternConfigurationTests
    {
        private void ClearTestFiles()
        {
            if (File.Exists(JsonConfiguration.GetPathForConfig<LecternConfiguration>()))
            {
                File.Delete(JsonConfiguration.GetPathForConfig<LecternConfiguration>());
            }

            JsonConfiguration.ForceClearCache();
        }

        [Fact]
        public void TestConfigSections()
        {
            LecternConfiguration test1Config = new LecternConfiguration()
            {
                BotName = "Test 1 Bot",
                CommandPrefix = "!"
            };

            JsonConfiguration.Save(test1Config, "test1");

            LecternConfiguration test1ConfigLoaded = JsonConfiguration.Load<LecternConfiguration>("test1");
            Assert.Equal(test1ConfigLoaded.BotName, test1Config.BotName);
            Assert.Equal(test1ConfigLoaded.CommandPrefix, test1Config.CommandPrefix);

            LecternConfiguration test2Config = new LecternConfiguration()
            {
                BotName = "Should be default",
                CommandPrefix = "#"
            };

            JsonConfiguration.Save(test2Config);

            LecternConfiguration test2ConfigLoaded = JsonConfiguration.Load<LecternConfiguration>();
            Assert.Equal(test2ConfigLoaded.BotName, test2Config.BotName);
            Assert.Equal(test2ConfigLoaded.CommandPrefix, test2Config.CommandPrefix);

            ClearTestFiles();
        }

        [Fact]
        public void TestConfigSaving()
        {
            LecternConfiguration test1Config = new LecternConfiguration()
            {
                BotName = "Test 1 Bot",
                CommandPrefix = "!"
            };

            JsonConfiguration.Save(test1Config, "test1");

            Assert.True(File.Exists(JsonConfiguration.GetPathForConfig<LecternConfiguration>()));
            string fileContent = File.ReadAllText(JsonConfiguration.GetPathForConfig<LecternConfiguration>());
            Assert.Equal(fileContent, "{\"test1\":{\"Plugins\":[],\"BotName\":\"Test 1 Bot\",\"CommandPrefix\":\"!\"}}");

            ClearTestFiles();
        }
        
    }
}
