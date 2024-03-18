using GKS.Web.Components;
using GKS.Web.Contracts;
using GKS.Web.WebItems;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace GKS.Web.Services;

public class RuntimeService(IHost _host, ILogger<RuntimeService> logger) : IRuntimeService
{
    public event EventHandler<StopEventArgs>? StopRequest;

    public bool IsStopping { get; private set; }

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

    public StopEventArgs StopRequested()
    {
        logger.LogTrace("Processing Stop Request.");
        var ea = new StopEventArgs();
        OnStopRequest(ea);

        logger.LogTrace($"Processed Stop Request: {nameof(ea.IsHandled)}: {ea.IsHandled} | {nameof(ea.IsAllowed)}: {ea.IsAllowed}");
        if (ea.IsHandled && ea.IsAllowed) Task.Run(Stop);
        return ea;
    }

    public void Stop()
    {
        logger.LogInformation($"Shutting down Runtime.");
        if (IsStopping) return;
        IsStopping = true;

        _host.StopAsync();
    }

    protected virtual void OnStopRequest(StopEventArgs ea) => StopRequest?.Invoke(this, ea);
}