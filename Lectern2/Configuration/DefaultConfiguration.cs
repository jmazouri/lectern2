using System;
using System.IO;
using Newtonsoft.Json;
using NLog;

namespace Lectern2.Configuration
{
    public class DefaultConfiguration<T> : IConfiguration<T> where T : DefaultConfiguration<T>
    {
        protected Logger Logger = LogManager.GetCurrentClassLogger();

        public DefaultConfiguration()
        {
            Name = typeof (T).Name;
        }

        [JsonIgnore]
        public string Name { get; private set; }

        [JsonIgnore]
        public string ConfigPath
        {
            get { return Path.Combine(Directory.GetCurrentDirectory(), Name + ".json"); }
        }

        public T Load()
        {
            try
            {
                string jsonContent = File.ReadAllText(ConfigPath);
                return JsonConvert.DeserializeObject<T>(jsonContent);
            }
            catch (Exception ex)
            {
                Logger.Error("Couldn't load config file for {0}, path was \"{1}\", exception: {2}", Name, ConfigPath, ex);
                throw;
            }
        }

        public void Save()
        {
            try
            {
                string jsonContent = JsonConvert.SerializeObject(this);
                File.WriteAllText(ConfigPath, jsonContent);
            }
            catch (Exception ex)
            {
                Logger.Error("Couldn't save config file for {0}, path was \"{1}\", exception: {2}", Name, ConfigPath, ex);
                throw;
            }
            
        }
    }
}
