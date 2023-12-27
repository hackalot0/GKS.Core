using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace GKS.Core.Data;

public class CollectionListener<TCol, T> where TCol : IEnumerable<T>, INotifyCollectionChanged
{
    public Action<T>? ItemAdded { get; set; }
    public Action<T>? ItemRemoved { get; set; }
    public TCol Source => source;

    private TCol source;

    public CollectionListener(TCol source, Action<T>? itemAdded, Action<T>? itemRemoved)
    {
        this.source = source;
        ItemAdded = itemAdded;
        ItemRemoved = itemRemoved;
    }
}