using Newtonsoft.Json;

namespace Lectern2.Configuration
{
    public class LecternConfiguration
    {
        public string SimplePluginPrefix { get; set; }

        public LecternConfiguration()
        {
            var config = new LecternConfiguration
            {
                SimplePluginPrefix = "/lc"
            };

            ConfigurationManager.Load(ref config);
            SimplePluginPrefix = config.SimplePluginPrefix;
        }

        public static LecternConfiguration Instance 
        {
            get
            {
                return GlobalContainer.Container.GetExport<LecternConfiguration>().Value;
            }
        }
        
    }
}
