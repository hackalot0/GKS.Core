using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GKS.Core.Data;

public class ObservableSet<T> : ObservableCollection<T>
{
    public ObservableSet() { }
    public ObservableSet(IEnumerable<T> collection) : base(collection) { }
    public ObservableSet(List<T> list) : base(list) { }

    public bool UseRemoveAddOnReplace { get; set; }
    public bool UseRemoveOnClear { get; set; }

    protected override void SetItem(int index, T item)
    {
        if (UseRemoveAddOnReplace)
        {
            RemoveAt(index);
            Insert(index, item);
        }
        else base.SetItem(index, item);
    }
    protected override void ClearItems()
    {
        if (UseRemoveOnClear) this.ForLoopReverse(a => Remove(a));
        else base.ClearItems();
    }
}