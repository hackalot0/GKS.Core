using GKS.Core.Data;
using System.Collections.Generic;

namespace GKS.Core.Structures;

public class BinaryList<T>(IList<T> list, IComparer<T>? comparer = null)
{
    public IList<T> List => list;
    public IComparer<T> Comparer => comparer;

    private readonly IList<T> list = list;
    private readonly IComparer<T> comparer = comparer ?? ItemComparer<T>.Default;

    public bool Add(T item) => BinaryListMethods.BinaryAdd(list, item, comparer);
    public bool Remove(T item) => BinaryListMethods.BinaryRemove(list, item, comparer);

    public int IndexOf(T item) => BinaryListMethods.BinarySearch(list, item, comparer);
    public bool Contains(T item) => BinaryListMethods.BinaryContains(list, item, comparer);
}