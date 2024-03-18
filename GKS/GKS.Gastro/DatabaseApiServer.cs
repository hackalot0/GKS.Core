using GKS.Web;
using GKS.Web.Components;

namespace GKS.Gastro;

public class DatabaseApiServer : ApiServer
{
    protected override void BeforeRun()
    {
        base.BeforeRun();

        ArgumentNullException.ThrowIfNull(RuntimeService);
        RuntimeService.StopRequest += RuntimeService_StopRequest;
    }

    private void RuntimeService_StopRequest(object? sender, StopEventArgs e)
    {
        e.IsHandled = true;
        e.IsAllowed = true;
    }
}