using GKS.Web.Contracts;
using GKS.Web.WebItems;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;

namespace GKS.Web.Services;

public class RuntimeService(IHost _host) : IRuntimeService
{
    private static readonly Process _process = Process.GetCurrentProcess();

    public StatsInfo GetStats()
    {
        var totalCpuTime = _process.TotalProcessorTime;
        var totalRunTime = DateTime.Now - _process.StartTime;
        var cpuUsage = Convert.ToDecimal(totalCpuTime.TotalMilliseconds / (totalRunTime.TotalMilliseconds * Environment.ProcessorCount));
        var ramUsage = _process.WorkingSet64;

        var hostConfig = _host.Services.GetService(typeof(IConfiguration)) as IConfiguration;
        ArgumentNullException.ThrowIfNull(hostConfig);

        var instanceName = hostConfig["Instance:Name"];
        var instanceID = hostConfig["Instance:ID"];

        return new()
        {
            AppName = instanceName,
            InstanceID = instanceID is null ? Guid.Empty : Guid.Parse(instanceID),
            Timestamp = DateTime.Now,
            CpuUsage = cpuUsage,
            RamUsage = ramUsage,
        };
    }
}