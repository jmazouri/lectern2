using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Lectern2.Configuration
{
    public static class JsonConfiguration
    {
        private static readonly Dictionary<string, JObject> ObjectCache = new Dictionary<string, JObject>(); 

        private static string GenerateConfigPath(string partName)
        {
            return Path.Combine(Directory.GetCurrentDirectory(), partName + ".json");
        }

        public static string GetPathForConfig<T>()
        {
            return GenerateConfigPath(typeof(T).Name);
        }

        public static void ForceClearCache()
        {
            ObjectCache.Clear();
        }

        public static void ForceClearCache<T>()
        {
            ObjectCache.Remove(typeof (T).Name);
        }

        /// <summary>
        /// Loads the configuration from the associated file.
        /// </summary>
        public static T Load<T>(string section = "default") where T : class, new()
        {
            string typeName = typeof (T).Name;
            string generatedPath = GenerateConfigPath(typeName);
            
            try
            {
                if (!File.Exists(generatedPath))
                {
                    Save<T>(null, section);
                }

                string jsonContent = File.ReadAllText(generatedPath);
                var jo = JObject.Parse(jsonContent);

                if (ObjectCache.ContainsKey(typeName))
                {
                    ObjectCache[typeName] = jo;
                }
                else
                {
                    ObjectCache.Add(typeName, jo);
                }

                var selectedSectionData = jo[section] ?? jo["default"];

                return selectedSectionData.ToObject<T>();
            }
            catch (Exception ex)
            {
                "JsonConfiguration".Log().Error("Couldn't load config file \"{0}\", section {1}. Exception: {2}", generatedPath, section, ex);
                throw;
            }
        }


        /// <summary>
        /// Saves the current configuration to the associated file.
        /// </summary>
        public static void Save<T>(T instance, string section = "default") where T : class, new()
        {
            string typeName = typeof (T).Name;
            string generatedPath = GenerateConfigPath(typeName);

            try
            {
                var newJObject = new JObject();

                JObject value;
                if (ObjectCache.TryGetValue(typeName, out value))
                {
                    JObject cur = value;
                    newJObject = cur;
                    newJObject[section] = JObject.FromObject(instance);
                }
                else
                {
                    newJObject[section] = JObject.FromObject(instance ?? new T());
                }

                string jsonContent = JsonConvert.SerializeObject(newJObject);
                File.WriteAllText(generatedPath, jsonContent);
                
            }
            catch (Exception ex)
            {
                "JsonConfiguration".Log().Error("Couldn't save config file \"{0}\", section {1}. Exception: {2}", generatedPath, section, ex);
                throw;
            }
            
        }
    }
}
