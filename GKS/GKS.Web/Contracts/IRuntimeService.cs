using GKS.Web.WebItems;

namespace GKS.Web.Contracts;

public interface IRuntimeService
{
    StatsInfo GetStats();
}