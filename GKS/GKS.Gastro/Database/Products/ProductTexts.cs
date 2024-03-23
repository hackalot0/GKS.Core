using GKS.Core.Models;
using GKS.Gastro.Database.Localization;

namespace GKS.Gastro.Database.Products;

public class ProductTexts : INameable, IDescribable, ILanguageDependant
{
    public required ContentLanguage? Language { get; set; }

    public required string? Name { get; set; }
    public string? Description { get; set; }
}