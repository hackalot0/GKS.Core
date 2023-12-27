using GKS.Core;

namespace GKS.TestingConsole;

internal class Program
{
    private static void Main(string[] args)
    {
        var osl = new ObservableStringList() { UseRemoveAddOnReplace = true, UseRemoveOnClear = true, };
        var oslListener = osl.Observe(a => Console.WriteLine("Added: " + a), a => Console.WriteLine("Removed: " + a));

        osl.Add("Hallo");
        osl.Add("Schöne");
        osl.Add("Welt");

        osl[1] = "Gruselige";

        osl.RemoveAt(1);

        osl.Clear();
    }
}