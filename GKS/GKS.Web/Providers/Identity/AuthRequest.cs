namespace GKS.Web.Providers.Identity;

public class AuthRequest
{
    public IIdentityInfo? Identity { get; set; }
    public string? Secret { get; set; }
}