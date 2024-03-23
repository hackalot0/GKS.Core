using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace GKS.Core.Structures;

public class ItemSet<T> : IList<T>, INotifyCollectionChanged
{
    public event NotifyCollectionChangedEventHandler? CollectionChanged;

    public event SenderEvent.Handler? Cleared;
    public event IndexedItemEvent<T, int>.Handler? ItemAdded;
    public event IndexedItemEvent<T, int>.Handler? ItemRemoved;
    public event IndexedItemChangeEvent<T, int>.Handler? ItemReplaced;

    public int Count => _items.Count;
    public bool IsReadOnly => ((IList<T>)_items).IsReadOnly;
    public T this[int index] { get => _items[index]; set => SetAt(index, value); }

    public bool UseRemoveForClear { get; set; }
    public bool UseRemoveAddForSet { get; set; }

    private readonly List<T> _items;

    public ItemSet() => _items = [];
    public ItemSet(int capacity) => _items = new List<T>(capacity);

    public void Clear()
    {
        if (UseRemoveForClear)
        {
            T[] items = new T[_items.Count];
            _items.CopyTo(items, 0);
            _items.Clear();
            OnCollectionChanged(new(NotifyCollectionChangedAction.Remove, items, 0));
            return;
        }

        _items.Clear();
        OnCollectionChanged(new(NotifyCollectionChangedAction.Reset));
    }
    public void Add(T item)
    {
        _items.Add(item);
        OnCollectionChanged(new(NotifyCollectionChangedAction.Add, item, Count));
    }
    public void Insert(int index, T item)
    {
        _items.Insert(index, item);
        OnCollectionChanged(new(NotifyCollectionChangedAction.Add, item, index));
    }
    public bool Remove(T item)
    {
        var index = IndexOf(item);
        if (index < 0) return false;
        _items.RemoveAt(index);
        OnCollectionChanged(new(NotifyCollectionChangedAction.Remove, item, index));
        return true;
    }
    public void RemoveAt(int index)
    {
        var item = _items[index];
        _items.RemoveAt(index);
        OnCollectionChanged(new(NotifyCollectionChangedAction.Remove, item, index));
    }
    public void SetAt(int index, T item)
    {
        var oldItem = _items[index];
        _items[index] = item;
        OnCollectionChanged(new(NotifyCollectionChangedAction.Replace, item, oldItem, index));
    }

    public int IndexOf(T item) => _items.IndexOf(item);
    public bool Contains(T item) => IndexOf(item) >= 0;
    public void CopyTo(T[] array, int arrayIndex) => _items.CopyTo(array, arrayIndex);

    public IEnumerator<T> GetEnumerator() => _items.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e) => CollectionChanged?.Invoke(this, e);
}