using Newtonsoft.Json;

namespace Lectern2.Configuration
{
    public class LecternConfiguration : ConfigurationHost
    {
        private LecternConfiguration()
        {
            /*
             * You can set defaults here, they get overridden
             * when the config gets loaded anyway
            */
            Load();
        }

        /// <summary>
        /// Gets an instance of LecternConfiguration
        /// </summary>
        /// <remarks>Returns the singleton from the IOC container.</remarks>
        public static LecternConfiguration Instance 
        {
            get
            {
                return GlobalContainer.Container.GetExport<LecternConfiguration>().Value;
            }
        }
        
    }
}
