namespace Lectern2.Configuration
{
    public interface IConfiguration
    {
        /// <summary>
        /// Loads the configuration from the associated file.
        /// </summary>
        void Load();

        /// <summary>
        /// Saves the current configuration to the associated file.
        /// </summary>
        void Save();
    }
}