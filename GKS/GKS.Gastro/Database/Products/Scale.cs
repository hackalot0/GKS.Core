namespace GKS.Gastro.Database.Products;

public class Scale(string name, string factorCode, decimal factor)
{
    public static IReadOnlyList<Scale> Defaults { get; } = [
        new Scale("Micro", "µ", 0.000_001m),
        new Scale("Centi", "c", 0.01m),
        new Scale("Deci", "d", 0.1m),
        new Scale("Milli", "m", 0.001m),
        new Scale("Kilo", "k", 1_000m),
        new Scale("Ton", "t", 1_000_000m),
    ];

    public string Name { get; set; } = name;
    public string FactorCode { get; set; } = factorCode;
    public decimal Factor { get; set; } = factor;
}