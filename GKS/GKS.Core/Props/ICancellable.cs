namespace GKS.Core.Models;

public interface ICancellable : ICanceled
{
    new bool IsCanceled { get; set; }
}