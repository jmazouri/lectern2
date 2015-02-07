using System;
using System.IO;
using Newtonsoft.Json;
using NLog;

namespace Lectern2.Configuration
{
    public static class ConfigurationManager
    {
        private static Logger Logger = LogManager.GetCurrentClassLogger();

        public static string ConfigPath(string Name)
        {
            return Path.Combine(Directory.GetCurrentDirectory(), Name + ".json"); 
        }

        /// <summary>
        /// Loads the configuration for the type.
        /// </summary>
        /// <typeparam name="T">The type to be deserialized to.</typeparam>
        /// <param name="instance">The instance that will be loaded. Note: should have default properties set.</param>
        public static void Load<T>(ref T instance)
        {
            string configPath = ConfigPath(typeof (T).Name);

            try
            {
                if (!File.Exists(configPath))
                {
                    Save<T>(instance);
                }

                string jsonContent = File.ReadAllText(configPath);
                JsonConvert.DeserializeObject<T>(jsonContent, new JsonSerializerSettings()
                {
                    ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
                });

                instance = JsonConvert.DeserializeObject<T>(jsonContent);
            }
            catch (Exception ex)
            {
                Logger.Error("Couldn't load config file \"{0}\", exception: {1}", configPath, ex);
                throw;
            }
        }

        public static void Save<T>(T instance)
        {
            string configPath = ConfigPath(typeof(T).Name);

            try
            {
                string jsonContent = JsonConvert.SerializeObject(instance);
                File.WriteAllText(configPath, jsonContent);
            }
            catch (Exception ex)
            {
                Logger.Error("Couldn't save config file \"{0}\", exception: {1}", configPath, ex);
                throw;
            }
            
        }
    }
}
