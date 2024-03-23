namespace GKS.Core.Models;

public interface IKeyed<T>
{
    T Key { get; }
}