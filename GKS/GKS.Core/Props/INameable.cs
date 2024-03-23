namespace GKS.Core.Models;

public interface INameable : INamed
{
    new string? Name { get; set; }
}