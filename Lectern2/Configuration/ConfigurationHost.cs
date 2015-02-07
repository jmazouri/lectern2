using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NLog;

namespace Lectern2.Configuration
{
    public class ConfigurationHost
    {
        private readonly Logger Logger = LogManager.GetCurrentClassLogger();

        [JsonIgnore]
        public string Name { get; set; }

        [JsonIgnore]
        public string ConfigPath
        {
            get { return Path.Combine(Directory.GetCurrentDirectory(), Name + ".json"); }
        }

        protected ConfigurationHost()
        {
            Name = GetType().Name;
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
                Logger.Error("Couldn't load config file \"{0}\", exception: {1}", ConfigPath, ex);
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
                Logger.Error("Couldn't save config file \"{0}\", exception: {1}", ConfigPath, ex);
                throw;
            }
            
        }
    }
}
