namespace GKS.Gastro.Database.Products;

public class Composition
{
    public Product? Product { get; set; }
    public decimal Amount { get; set; }
    public UnitScale? UnitScale { get; set; }
}