using System.Collections.Generic;
using Newtonsoft.Json;

namespace Lectern2.Configuration
{
    public class LecternConfiguration
    {
        public HashSet<string> Plugins { get; protected set; }
        public string BotName { get; set; }
        public string CommandPrefix { get; set; }

        public LecternConfiguration()
        {
            /*
             * You can set defaults here, they get overridden
             * when the config gets loaded anyway
            */
            Plugins = new HashSet<string>();
            BotName = "Lectern";
            CommandPrefix = "!";
        }
    }
}
