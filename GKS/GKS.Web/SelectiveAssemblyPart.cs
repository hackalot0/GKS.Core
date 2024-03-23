using Microsoft.AspNetCore.Mvc.ApplicationParts;
using System.Reflection;

namespace GKS.Web;

public class SelectiveAssemblyPart(Assembly assembly, Func<TypeInfo, bool> selector) : ApplicationPart, IApplicationPartTypeProvider
{
    public Func<TypeInfo, bool> Selector { get; } = selector;
    public Assembly Assembly { get; } = assembly;

    public IEnumerable<TypeInfo> Types => Assembly.DefinedTypes.Where(Selector);

    public override string Name => Assembly.GetName().Name!;
}