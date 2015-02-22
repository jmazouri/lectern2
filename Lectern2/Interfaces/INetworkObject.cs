using Lectern2.Core;

namespace Lectern2.Interfaces
{
    public interface INetworkObject
    {
        Network Network { get; }
        string Name { get; }
        bool Load(Network network);
    }
}
