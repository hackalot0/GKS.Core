using GKS.Web.Providers.Identity;

namespace GKS.Web.Providers;

public interface IIdentityProvider_V1
{
    AuthInfo Authenticate(AuthRequest authRequest);
    AuthInfo Status(AuthRequest authRequest);
}