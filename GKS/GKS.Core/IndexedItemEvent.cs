namespace GKS.Core;

public abstract class IndexedItemEvent<T, TIndex> : ItemEvent<T>
{
    public new delegate void Handler(Args args);

    public new class Args(object sender, T item, TIndex index) : SenderEvent.Args(sender)
    {
        public T Item { get; } = item;
        public TIndex Index { get; } = index;
    }
}