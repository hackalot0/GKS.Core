namespace GKS.Gastro.Database.Products;

public class Unit(string name, string unitCode)
{
    public static IReadOnlyList<Unit> Defaults { get; } = [
        new Unit("Gramm", "g"),
        new Unit("Meter", "m"),
    ];

    public string Name { get; set; } = name;
    public string UnitCode { get; set; } = unitCode;
}