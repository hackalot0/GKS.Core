namespace GKS.Web.Providers.Identity;

public class AuthInfo
{
    public IIdentityInfo? Identity { get; set; }

    public bool IsSuccess { get; set; }
    public string? Message { get; set; }

    public DateTime ValidSince { get; set; }
    public DateTime ValidUntil { get; set; }
}