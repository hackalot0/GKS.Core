namespace GKS.Core;

public abstract class ItemEvent<T, TIndex> : ItemEvent<T>
{
    public new delegate void Handler(Args args);

    public new class Args(object sender, T item, TIndex index) : SenderEvent.Args(sender)
    {
        public T Item { get; } = item;
        public TIndex Index { get; } = index;
    }
}

public abstract class ItemEvent<T> : SenderEvent
{
    public new delegate void Handler(Args args);

    public new class Args(object sender, T item) : SenderEvent.Args(sender)
    {
        public T Item { get; } = item;
    }
}