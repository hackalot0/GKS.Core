using GKS.Web;
using GKS.Web.Components;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GKS.Universe;

public class IdentityProviderApiServer : ApiServer
{
    protected override void OnStopRequest(StopEventArgs ea)
    {
        ea.IsAllowed = true;
        ea.IsHandled = true;
        //base.OnStopRequest(ea);
    }
}