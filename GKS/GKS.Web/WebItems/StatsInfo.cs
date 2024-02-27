namespace GKS.Web.WebItems;

public class StatsInfo
{
    public string? AppName { get; init; }
    public Guid? InstanceID { get; init; }
    public DateTime Timestamp { get; init; }
    public decimal CpuUsage { get; init; }
    public decimal RamUsage { get; init; }
}