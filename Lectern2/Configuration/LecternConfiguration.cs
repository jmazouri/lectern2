using Newtonsoft.Json;

namespace Lectern2.Configuration
{
    public class LecternConfiguration
    {
        public string SimplePluginPrefix { get; set; }

        private LecternConfiguration()
        {
            SimplePluginPrefix = "/ln";
        }

        public static LecternConfiguration Instance 
        {
            get
            {
                LecternConfiguration config = GlobalContainer.Container.GetExport<LecternConfiguration>().Value;
                ConfigurationManager.Load(ref config);
                return config;
            }
        }
        
    }
}
