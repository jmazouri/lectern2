using System;
using System.IO;
using Newtonsoft.Json;

namespace Lectern2.Configuration
{
    public class JsonConfiguration : IConfiguration
    {
        [NonSerialized]
        public readonly string ConfigName;
        [NonSerialized]
        public readonly string ConfigPath;

        protected JsonConfiguration()
        {
            ConfigName = GetType().Name;
            ConfigPath = Path.Combine(Directory.GetCurrentDirectory(), ConfigName + ".json");
        }

        /// <summary>
        /// Loads the configuration from the associated file.
        /// </summary>
        public void Load()
        {
            try
            {
                if (!File.Exists(ConfigPath))
                {
                    Save();
                }

                string jsonContent = File.ReadAllText(ConfigPath);
                JsonConvert.PopulateObject(jsonContent, this);
            }
            catch (Exception ex)
            {
                this.Log().Error("Couldn't load config file \"{0}\", exception: {1}", ConfigPath, ex);
                throw;
            }
        }

        /// <summary>
        /// Saves the current configuration to the associated file.
        /// </summary>
        public void Save()
        {
            try
            {
                string jsonContent = JsonConvert.SerializeObject(this);
                File.WriteAllText(ConfigPath, jsonContent);
            }
            catch (Exception ex)
            {
                this.Log().Error("Couldn't save config file \"{0}\", exception: {1}", ConfigPath, ex);
                throw;
            }
            
        }
    }
}
