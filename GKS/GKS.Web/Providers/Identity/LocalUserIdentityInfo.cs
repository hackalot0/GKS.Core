namespace GKS.Web.Providers.Identity;

public class LocalUserIdentityInfo(Guid id) : IIdentityInfo
{
    public Guid ID { get; } = id;

    public string? Username { get; set; }
}