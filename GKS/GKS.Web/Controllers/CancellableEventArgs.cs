namespace GKS.Web.Controllers;

public abstract class CancellableEventArgs : EventArgs
{
    public bool Cancel { get; set; }
}
