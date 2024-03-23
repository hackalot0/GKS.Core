using GKS.Core.Models;

namespace GKS.Gastro.Database.Localization;

public class Language(string? name, string nativeName, string cultureCode) : KeyedItem, INameable
{
    public IReadOnlyList<Language> Defaults { get; } = [
        new("German", "Deutsch", "de-de"),
        new("English", "English", "en-us"),
    ];

    public string? Name { get; set; } = name;
    public string NativeName { get; set; } = nativeName;
    public string CultureCode { get; set; } = cultureCode;
}