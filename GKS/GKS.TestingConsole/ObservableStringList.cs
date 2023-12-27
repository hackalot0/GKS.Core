// See https://aka.ms/new-console-template for more information
using GKS.Core.Data;
using System.Collections.ObjectModel;

public class ObservableStringList : ObservableSet<string>
{
    public ObservableStringList() { }
    public ObservableStringList(IEnumerable<string> collection) : base(collection) { }
    public ObservableStringList(List<string> list) : base(list) { }
}