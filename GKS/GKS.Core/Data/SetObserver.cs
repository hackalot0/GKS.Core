﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace GKS.Core.Data;

public class SetObserver<T> : DisposableBase
{
    public Action<T>? ItemAdded { get; set; }
    public Action<T>? ItemRemoved { get; set; }
    public Action? Cleared { get; set; }

    public IEnumerable<T> Source => source;

    private readonly IEnumerable<T> source;
    private readonly INotifyCollectionChanged sourceNCC;

    public SetObserver(IEnumerable<T> source, Action<T>? itemAdded = null, Action<T>? itemRemoved = null, Action? cleared = null)
    {
        if (source is INotifyCollectionChanged ncc) sourceNCC = ncc;
        else throw new InvalidOperationException($"Argument \"{nameof(source)}\" must implement <{nameof(INotifyCollectionChanged)}>!");

        sourceNCC.CollectionChanged += Source_CollectionChanged;

        this.source = source;
        ItemAdded = itemAdded;
        ItemRemoved = itemRemoved;
        Cleared = cleared;
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            sourceNCC.CollectionChanged -= Source_CollectionChanged;
        }
        base.Dispose(disposing);
    }

    protected virtual void OnItemAdded(T item) => ItemAdded?.Invoke(item);
    protected virtual void OnItemRemoved(T item) => ItemRemoved?.Invoke(item);
    protected virtual void OnCleared() => Cleared?.Invoke();

    private void Source_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        var newItems = e.NewItems?.OfType<T>();
        var oldItems = e.OldItems?.OfType<T>();

        switch (e.Action)
        {
            case NotifyCollectionChangedAction.Add: newItems?.ForEach(OnItemAdded); break;
            case NotifyCollectionChangedAction.Remove: oldItems?.ForEach(OnItemRemoved); break;

            case NotifyCollectionChangedAction.Replace:
                oldItems?.ForEach(OnItemRemoved);
                newItems?.ForEach(OnItemAdded);
                break;

            case NotifyCollectionChangedAction.Reset: OnCleared(); break;
        }
    }
}