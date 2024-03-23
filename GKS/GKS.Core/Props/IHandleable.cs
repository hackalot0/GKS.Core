namespace GKS.Core.Models;

public interface IHandleable : IHandled
{
    new bool IsHandled { get; set; }
}