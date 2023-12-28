using System;
using System.Collections;
using System.Collections.Generic;

namespace GKS.Core.Data;

public class OrderComparer<T> : IEqualityComparer<T>, IComparer<T>
{
    public static OrderComparer<T> Default => _default ??= new();
    private static OrderComparer<T>? _default;

    public Comparison<T> Comparison { get => comparison; set => comparison = value ?? DefaultComparison; }

    private Comparison<T> comparison = DefaultComparison;

    public int Compare(T x, T y) => comparison(x, y);
    public bool Equals(T x, T y) => Compare(x, y) == 0;

    public int GetHashCode(T t) => t?.GetHashCode() ?? 0;

    public static OrderComparer<T> Create(Comparison<T> comparison) => new() { Comparison = comparison };
    public static int DefaultComparison(T x, T y)
    {
        if (ReferenceEquals(x, y)) return 0;

        if (y is null) return 1;
        if (x is null) return -1;

        if (x is IComparable<T> cgX && y is T tY) return cgX.CompareTo(tY);
        if (y is IComparable<T> cgY && x is T tX) return cgY.CompareTo(tX) * -1;

        if (x is IComparable cX) return cX.CompareTo(y);
        if (y is IComparable cY) return cY.CompareTo(x) * -1;

        return x.GetHashCode().CompareTo(y.GetHashCode());
    }
}

public class OrderComparer : OrderComparer<object?>, IEqualityComparer, IComparer { }