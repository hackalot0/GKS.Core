using GKS.Core.Models;

namespace GKS.Gastro.Database.Localization;

public class Language(string? name, string nativeName, string iso2) : KeyedItem, INameable
{
    public IReadOnlyList<Language> Defaults { get; } = [
        new("German", "Deutsch", "de") { ISO3 = "deu", CultureCode = "de-de" },
        new("English", "English", "en") { ISO3 = "eng", CultureCode = "en-us" },
    ];

    public string? Name { get; set; } = name;
    public string NativeName { get; set; } = nativeName;
    public string ISO2 { get; set; } = iso2;
    public string ISO3 { get; set; }
    public string CultureCode { get; set; }
}