using GKS.Core.Data;

namespace GKS.Core.Structures;

public interface ITree<T> where T : ITree<T>
{
    T? Root { get; }
    T? Parent { get; }
    ObservableSet<T> Nodes { get; }
}