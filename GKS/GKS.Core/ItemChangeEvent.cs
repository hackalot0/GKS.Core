namespace GKS.Core;

public abstract class ItemChangeEvent<T> : ItemEvent<T>
{
    public new delegate void Handler(Args args);

    public new class Args(object sender, T item, T oldItem) : ItemEvent<T>.Args(sender, item)
    {
        public T OldItem { get; } = oldItem;
    }
}