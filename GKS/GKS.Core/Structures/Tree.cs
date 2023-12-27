using GKS.Core.Data;

namespace GKS.Core.Structures;

public class Tree<T> where T : Tree<T>
{
    public T? Root => Parent is null ? (T)this : Parent.Root;
    public T? Parent { get; protected set; }
    public ObservableSet<T> Nodes => nodes;

    private readonly ObservableSet<T> nodes;
    private readonly SetObserver<T> nodesObserver;

    public Tree()
    {
        nodes = new() { UseRemoveAddOnReplace = true, UseRemoveOnClear = true, };
        nodesObserver = nodes.Observe(Node_Added, Node_Removed);
    }

    protected virtual void Node_Added(T t)
    {
        if (t is null) return;
        t.Parent = (T)this;
    }
    protected virtual void Node_Removed(T t)
    {
        if (t is null) return;
        t.Parent = null;
    }
}