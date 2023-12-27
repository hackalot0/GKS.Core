using GKS.Core.Data;
using System.Collections;
using System.Collections.Generic;

namespace GKS.Core.Structures;

public class BinaryCollection<T>(IComparer<T>? comparer = null) : ICollection<T>
{
    protected IList<T> List => binaryList.List;
    public IComparer<T> Comparer => binaryList.Comparer;

    public int Count => List.Count;
    public bool IsReadOnly => List.IsReadOnly;

    private readonly BinaryList<T> binaryList = new([], comparer ?? ItemComparer<T>.Default);

    public void Add(T item) => binaryList.Add(item);
    public bool Remove(T item) => binaryList.Remove(item);
    public void Clear() => List.Clear();

    public bool Contains(T item) => binaryList.Contains(item);
    public void CopyTo(T[] array, int arrayIndex) => List.CopyTo(array, arrayIndex);

    public IEnumerator<T> GetEnumerator() => List.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}