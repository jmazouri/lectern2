using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NLog;

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
