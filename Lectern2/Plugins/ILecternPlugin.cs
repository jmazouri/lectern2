using Lectern2.Bridges;

namespace Lectern2.Plugins
{
    public interface ILecternPlugin
    {
        ILecternBridge Bridge { get; set; }
        string Name { get; }
        void Load();
        void Unload();
    }
}
