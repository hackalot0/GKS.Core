namespace GKS.Core;

public class ItemEvent<T> : SenderEvent
{
    public new delegate void Handler(Args args);

    public new class Args(object sender, T item) : SenderEvent.Args(sender)
    {
        public T Item { get; } = item;
    }
}
