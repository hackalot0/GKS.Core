using System;
using System.Collections;
using System.Collections.Generic;

namespace GKS.Core.Data;

public class EqualityComparer<T> : IEqualityComparer<T>
{
    public static EqualityComparer<T> Default => _default ??= new();
    private static EqualityComparer<T>? _default;

    public Func<T, T, bool> Comparison { get => comparison; set => comparison = value ?? DefaultComparison; }

    private Func<T, T, bool> comparison = DefaultComparison;

    public bool Equals(T x, T y) => comparison(x, y);
    public int GetHashCode(T t) => t?.GetHashCode() ?? 0;

    public static EqualityComparer<T> Create(Func<T, T, bool> comparison) => new() { Comparison = comparison };
    public static bool DefaultComparison(T x, T y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (y is null || x is null) return false;
        return x.GetHashCode().Equals(y.GetHashCode());
    }
}

public class EqualityComparer : EqualityComparer<object?>, IEqualityComparer { }