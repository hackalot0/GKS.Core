namespace GKS.Core.Models;

public interface IAllowable : IAllowed
{
    new bool IsAllowed { get; set; }
}