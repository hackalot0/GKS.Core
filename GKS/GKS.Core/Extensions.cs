﻿using GKS.Core.Data;
using GKS.Core.Structures;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace GKS.Core;

public static class Extensions
{
    public static SetObserver<T> Observe<T>(this IEnumerable<T> source, Action<T>? itemAdded = null, Action<T>? itemRemoved = null) => new(source, itemAdded, itemRemoved);

    public static IList<T> ForLoop<T>(this IList<T> source, Action<T> action)
    {
        for (int i = 0; i < source.Count; i++) action(source[i]);
        return source;
    }
    public static IList<T> ForLoopReverse<T>(this IList<T> source, Action<T> action)
    {
        for (int i = source.Count - 1; i >= 0; i--) action(source[i]);
        return source;
    }

    public static int BinarySearch<T>(this IList<T> list, T item, IComparer<T>? comparer = null) => BinaryListMethods.BinarySearch(list, item, comparer);
    public static bool BinaryContains<T>(this IList<T> list, T item, IComparer<T>? comparer = null) => BinaryListMethods.BinaryContains(list, item, comparer);
    public static bool BinaryAdd<T>(this IList<T> list, T item, IComparer<T>? comparer = null) => BinaryListMethods.BinaryAdd(list, item, comparer);
    public static bool BinaryRemove<T>(this IList<T> list, T item, IComparer<T>? comparer = null) => BinaryListMethods.BinaryRemove(list, item, comparer);

    public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action)
    {
        foreach (var item in source) action(item);
        return source;
    }
    public static ICollection<T> AddRange<T>(this ICollection<T> col, IEnumerable<T> source)
    {
        source.ForEach(col.Add);
        return col;
    }
    public static ICollection<T> RemoveRange<T>(this ICollection<T> col, IEnumerable<T> source) => RemoveRange<T>(col, source, out _);
    public static ICollection<T> RemoveRange<T>(this ICollection<T> col, IEnumerable<T> source, out int removeCount)
    {
        removeCount = source.Count(col.Remove);
        return col;
    }

    public static SyncInfo<T> Sync<T>(this SyncInfo<T> syncInfo)
    {
        syncInfo.Comparer ??= OrderComparer<T>.Default;

        SyncTo(syncInfo.Source, syncInfo.Target, out int added, out int removed, syncInfo.Comparer);

        syncInfo.Added = added;
        syncInfo.Removed = removed;

        return syncInfo;
    }

    public static SyncInfo<T> SyncTo<T>(this IEnumerable<T> source, ICollection<T> destination, IEqualityComparer<T>? comparer = null) => Sync(new SyncInfo<T>(source, destination, comparer ?? OrderComparer<T>.Default));
    public static SyncInfo<T> SyncFrom<T>(this ICollection<T> destination, IEnumerable<T> source, IEqualityComparer<T>? comparer = null) => SyncTo(source, destination, comparer);

    public static IEnumerable<T> SyncTo<T>(this IEnumerable<T> source, ICollection<T> destination, out int added, out int removed, IEqualityComparer<T>? comparer = null)
    {
        comparer ??= OrderComparer<T>.Default;

        var toAdd = destination.Except(source, comparer).ToList();
        var toRemove = source.Except(destination, comparer).ToList();

        added = toAdd.Count;
        destination.RemoveRange(toRemove, out removed);

        return source;
    }
    public static ICollection<T> SyncFrom<T>(this ICollection<T> destination, IEnumerable<T> source, out int added, out int removed, IEqualityComparer<T>? comparer = null)
    {
        SyncTo(source, destination, out added, out removed, comparer);
        return destination;
    }
}