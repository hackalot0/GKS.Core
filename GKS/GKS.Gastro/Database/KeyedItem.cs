using GKS.Core.Models;

namespace GKS.Gastro.Database;

public class KeyedItem : IKeyable<int>
{
    public int Key { get; set; }
}