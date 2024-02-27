namespace GKS.Core.Models;

public interface ICountable : ICounted
{
    new int? Count { get; set; }
}