using GKS.Core.Data;
using System.Collections.Generic;

namespace GKS.Core.Structures;

public static class BinaryListMethods
{
    public static bool BinaryContains<T>(IList<T> list, T item, IComparer<T>? comparer = null) => BinarySearch(list, item, comparer) >= 0;
    public static int BinarySearch<T>(IList<T> list, T item, IComparer<T>? comparer = null)
    {
        comparer ??= ItemComparer<T>.Default;

        int low = 0;
        int high = list.Count - 1;

        while (low <= high)
        {
            int mid = (low + high) / 2;
            int comparisonResult = comparer.Compare(list[mid], item);

            if (comparisonResult == 0) return mid;
            else if (comparisonResult < 0) low = mid + 1;
            else high = mid - 1;
        }

        return ~low;
    }
    public static bool BinaryAdd<T>(IList<T> list, T item, IComparer<T>? comparer = null)
    {
        comparer ??= ItemComparer<T>.Default;

        int index = BinarySearch(list, item, comparer);
        if (index >= 0) return false;
        list.Insert(~index, item);
        return true;
    }
    public static bool BinaryRemove<T>(IList<T> list, T item, IComparer<T>? comparer = null)
    {
        comparer ??= ItemComparer<T>.Default;

        int index = BinarySearch(list, item, comparer);
        if (index < 0) return false;
        list.RemoveAt(index);
        return true;
    }
}