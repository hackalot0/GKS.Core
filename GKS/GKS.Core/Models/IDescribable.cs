namespace GKS.Core.Models;

public interface IDescribable : IDescribed
{
    new string? Description { get; set; }
}