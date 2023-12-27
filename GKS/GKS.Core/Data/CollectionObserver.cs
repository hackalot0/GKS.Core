using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace GKS.Core.Data;

public class CollectionObserver<T>
{
    public Action<T>? ItemAdded { get; set; }
    public Action<T>? ItemRemoved { get; set; }

    public IEnumerable<T> Source => source;

    private IEnumerable<T> source;
    private INotifyCollectionChanged sourceNCC;

    public CollectionObserver(IEnumerable<T> source, Action<T>? itemAdded = null, Action<T>? itemRemoved = null)
    {
        if (source is INotifyCollectionChanged ncc) sourceNCC = ncc;
        else throw new InvalidOperationException($"Argument \"{nameof(source)}\" must implement <{nameof(INotifyCollectionChanged)}>!");

        sourceNCC.CollectionChanged += Source_CollectionChanged;

        this.source = source;
        ItemAdded = itemAdded;
        ItemRemoved = itemRemoved;
    }

    protected virtual void OnItemAdded(T item) => ItemAdded?.Invoke(item);
    protected virtual void OnItemRemoved(T item) => ItemRemoved?.Invoke(item);

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

            case NotifyCollectionChangedAction.Reset:
                break;
        }
    }
}