using GKS.Gastro.Contracts;
using GKS.Gastro.WebItems;
using Microsoft.AspNetCore.Builder;
using System.Diagnostics;

namespace GKS.Gastro.Services;

public class RuntimeService : IRuntimeService
{
    private static Process _process = Process.GetCurrentProcess();

    private WebApplication _webApp;

    public RuntimeService(WebApplication webApp)
    {
        _webApp = webApp;
    }

    public StatsInfo GetStats()
    {
        var totalCpuTime = _process.TotalProcessorTime;
        var totalRunTime = DateTime.Now - _process.StartTime;
        var cpuUsage = Convert.ToDecimal(totalCpuTime.TotalMilliseconds / (totalRunTime.TotalMilliseconds * Environment.ProcessorCount));
        var ramUsage = _process.WorkingSet64;

        var instanceName = _webApp.Configuration["Instance:Name"];
        var instanceID = _webApp.Configuration["Instance:ID"];

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