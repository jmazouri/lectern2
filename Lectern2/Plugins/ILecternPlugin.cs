namespace Lectern2.Plugins
{
    public interface ILecternPlugin
    {
        string Name { get; }
        void Load();
        void Unload();
    }
}
