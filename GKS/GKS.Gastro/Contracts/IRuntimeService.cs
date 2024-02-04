using GKS.Gastro.WebItems;

namespace GKS.Gastro.Contracts;

public interface IRuntimeService
{
    StatsInfo GetStats();
}