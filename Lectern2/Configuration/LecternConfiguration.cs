using Newtonsoft.Json;

namespace Lectern2.Configuration
{
    public class LecternConfiguration : DefaultConfiguration<LecternConfiguration>
    {
        [JsonProperty]
        public string SimplePluginPrefix { get; protected set; }

        public LecternConfiguration()
        {
            SimplePluginPrefix = "/lc";
        }
    }
}
