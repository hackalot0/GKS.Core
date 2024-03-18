using GKS.Core.Models;

namespace GKS.Gastro.Database.Localization;

public class Naming : INameable
{
    public ActiveLanguage? ActiveLanguage { get; set; }

    public required string? Name { get; set; }
}