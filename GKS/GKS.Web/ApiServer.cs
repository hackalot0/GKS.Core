using GKS.Web.Contracts;
using GKS.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace GKS.Web;

public class ApiServer : IApiServer
{
    private static readonly Assembly __assembly = typeof(ApiServer).Assembly;

    private WebApplicationOptions? _options;
    private WebApplicationBuilder? _builder;
    private WebApplication? _webApp;
    private IRuntimeService? _runtimeService;

    public WebApplication? WebApp => _webApp;
    public IRuntimeService? RuntimeService => _runtimeService;

    public ApiServer() { }

    public virtual void Init(WebApplicationOptions? options = default)
    {
        _options = new()
        {
            Args = options?.Args ?? Environment.GetCommandLineArgs(),
            ApplicationName = __assembly.FullName,
            EnvironmentName = options?.EnvironmentName ?? Environments.Development,
        };

        _builder = WebApplication.CreateSlimBuilder(_options);

        InitConfiguration(_builder);
        InitServices(_builder);

        _webApp = _builder.Build();

        InitWebApp(_webApp);
    }
    public virtual void InitConfiguration(IHostApplicationBuilder builder)
    {
        builder.Configuration.AddJsonFile($"config.{builder.Environment.EnvironmentName.ToLowerInvariant()}.json", optional: true, reloadOnChange: true);
    }
    public virtual void InitServices(IHostApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IRuntimeService, RuntimeService>();
        builder.Services.AddControllers().ConfigureApplicationPartManager(apm =>
        {
            var appParts = apm.ApplicationParts;
            appParts.Clear();
            appParts.Add(new AssemblyPart(__assembly));
        });
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
    }
    public virtual void InitWebApp(WebApplication webApp)
    {
        webApp.Configuration["General:Endpoints"]?.Split(";").ToList().ForEach(webApp.Urls.Add);

        var route = webApp.Configuration["Api:Route"];
        ArgumentException.ThrowIfNullOrWhiteSpace(route);
        webApp.MapControllerRoute(
            name: "default",
            pattern: route,
            defaults: new
            {
                controller = "Controller",
                action = "Action"
            });

        if (webApp.Environment.IsDevelopment())
        {
            webApp.UseSwagger();
            webApp.UseSwaggerUI();
        }

        webApp.UseRouting();
        webApp.MapControllers();
    }

    public void Run()
    {
        BeforeRun();
        _webApp?.Run();
    }
    public Task? RunAsync(CancellationToken token = default)
    {
        BeforeRun();
        return _webApp?.RunAsync(token);
    }

    protected virtual void BeforeRun()
    {
        _runtimeService = _webApp?.Services.GetService<IRuntimeService>();
    }
}