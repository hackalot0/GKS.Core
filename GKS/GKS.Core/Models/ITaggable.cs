namespace GKS.Core.Models;

public interface ITaggable : ITagged
{
    new object? Tag { get; set; }
}