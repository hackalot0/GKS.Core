using System.Collections.Generic;

namespace GKS.Core;

public class SyncInfo<T>
{
    public IEnumerable<T> Source { get; set; }
    public ICollection<T> Target { get; set; }

    public IEqualityComparer<T> Comparer { get; set; }

    public int Added { get; set; }
    public int Removed { get; set; }

    public SyncInfo(IEnumerable<T> source, ICollection<T> target, IEqualityComparer<T> comparer, int added = 0, int removed = 0)
    {
        Source = source;
        Target = target;
        Comparer = comparer;

        Added = added;
        Removed = removed;
    }
}
public class SyncInfo : SyncInfo<object?>
{
    public SyncInfo(IEnumerable<object?> source, ICollection<object?> target, IEqualityComparer<object?> comparer, int added = 0, int removed = 0) : base(source, target, comparer, added, removed) { }
}