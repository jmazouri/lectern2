using Newtonsoft.Json;

namespace Lectern2.Configuration
{
    public class LecternConfiguration : DefaultConfiguration<LecternConfiguration>
    {
        public string SimplePluginPrefix { get; set; }

        public LecternConfiguration()
        {
            SimplePluginPrefix = "/lc";
        }
    }
}
