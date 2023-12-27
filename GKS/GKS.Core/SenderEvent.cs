namespace GKS.Core;

public class SenderEvent
{
    public delegate void Handler(Args args);

    public class Args(object sender)
    {
        public object Sender { get; } = sender;
    }
}
