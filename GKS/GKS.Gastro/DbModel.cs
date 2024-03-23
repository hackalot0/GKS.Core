using GKS.Gastro.Database.Localization;
using System.Collections.ObjectModel;

namespace GKS.Gastro;

public class Set<T> : Collection<T>
{
    protected override void ClearItems()
    {
        base.ClearItems();
    }
    protected override void InsertItem(int index, T item)
    {
        base.InsertItem(index, item);
    }
    protected override void RemoveItem(int index)
    {
        base.RemoveItem(index);
    }
    protected override void SetItem(int index, T item)
    {
        base.SetItem(index, item);
    }
}

public class DbSet<T> : Set<T>
{

}

public class DbModel
{
}