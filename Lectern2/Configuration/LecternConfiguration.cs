using System.Collections.Generic;
using Newtonsoft.Json;

namespace Lectern2.Configuration
{
    public class LecternConfiguration : JsonConfiguration
    {
        public HashSet<string> Plugins { get; internal set; }
        public string BotName { get; internal set; }
        public string CommandPrefix { get; internal set; }

        private LecternConfiguration()
        {
            /*
             * You can set defaults here, they get overridden
             * when the config gets loaded anyway
            */
            Plugins = new HashSet<string>();
            BotName = "Lectern";
            CommandPrefix = "!";

            Load();
        }

        public static LecternConfiguration Instance
        {
            get { return GlobalContainer.Container.GetExport<LecternConfiguration>().Value; }
        }
    }
}
