namespace GKS.Core;

public abstract class SenderEvent
{
    public delegate void Handler(Args args);

    public class Args(object sender)
    {
        public object Sender { get; } = sender;
    }
}