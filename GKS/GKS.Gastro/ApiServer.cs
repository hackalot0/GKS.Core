using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GKS.Gastro;

public class ApiServer
{
    /*

    var builder = WebApplication.CreateSlimBuilder(new WebApplicationOptions()
    {
        Args = args,
        ApplicationName = typeof(Program).Assembly.FullName,
        EnvironmentName = Environments.Staging,
    });

    builder.Configuration.AddJsonFile($"config.{builder.Environment.EnvironmentName.ToLowerInvariant()}.json", optional: true, reloadOnChange: true);
    builder.Services.AddControllers();

    var app = builder.Build();

    app.Configuration["General:Endpoints"]?.Split(";").ToList().ForEach(app.Urls.Add);

    app.UseRouting();
    app.MapControllers();

    app.Run();

    */

    private WebApplication webApp;

    public ApiServer()
    {
        var builder = WebApplication.CreateSlimBuilder(new WebApplicationOptions()
        {
            Args = Environment.GetCommandLineArgs(),
            ApplicationName = typeof(ApiServer).Assembly.FullName,
            EnvironmentName = Environments.Staging,
        });

        builder.Configuration.AddJsonFile($"config.{builder.Environment.EnvironmentName.ToLowerInvariant()}.json", optional: true, reloadOnChange: true);
        builder.Services.AddControllers();

        webApp = builder.Build();
    }

    public void Run()
    {
        webApp.Run();
    }
}