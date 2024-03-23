namespace GKS.Gastro.Database.Localization;

internal interface ILanguageDependant
{
    ContentLanguage? Language { get; set; }
}