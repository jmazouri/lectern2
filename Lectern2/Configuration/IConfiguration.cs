namespace Lectern2.Configuration
{
    public interface IConfiguration<T>
    {
        string Name { get; }
        string ConfigPath { get; }
        T Load();
        void Save();
    }
}
