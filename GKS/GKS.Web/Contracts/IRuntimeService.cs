using GKS.Web.Components;
using GKS.Web.WebItems;

namespace GKS.Web.Contracts;

public interface IRuntimeService
{
    event EventHandler<StopEventArgs>? StopRequest;

    StatsInfo GetStats();

    StopEventArgs StopRequested();
}