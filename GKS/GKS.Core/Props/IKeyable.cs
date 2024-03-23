namespace GKS.Core.Models;

public interface IKeyable<T> : IKeyed<T>
{
    new T Key { get; set; }
}