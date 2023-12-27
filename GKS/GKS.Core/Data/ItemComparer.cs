using System;
using System.Collections;
using System.Collections.Generic;

namespace GKS.Core.Data;

public class ItemComparer<T> : IEqualityComparer<T>, IComparer<T>, IComparer, IEqualityComparer
{
    public static ItemComparer<T> Default => _default ??= new();
    private static ItemComparer<T>? _default;

    public int Compare(T x, T y) => Compare(objX: x, objY: y);

    public int Compare(object? objX, object? objY)
    {
        if (ReferenceEquals(objX, objY)) return 0;

        if (objY is null) return 1;
        if (objX is null) return -1;

        if (objX is IComparable<T> cgX && objY is T tY) return cgX.CompareTo(tY);
        if (objY is IComparable<T> cgY && objX is T tX) return cgY.CompareTo(tX) * -1;

        if (objX is IComparable cX) return cX.CompareTo(objY);
        if (objY is IComparable cY) return cY.CompareTo(objX) * -1;

        return GetHashCode(objX).CompareTo(GetHashCode(objY));
    }

    public bool Equals(T x, T y) => Compare(x, y) == 0;
    public new bool Equals(object? objX, object? objY) => Compare(objX, objY) == 0;

    public int GetHashCode(T t) => t?.GetHashCode() ?? 0;
    public int GetHashCode(object? obj) => obj?.GetHashCode() ?? 0;
}