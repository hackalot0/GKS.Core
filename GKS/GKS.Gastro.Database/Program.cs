using GKS.Gastro;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

var apiServer = new DatabaseApiServer();

apiServer.Init(new WebApplicationOptions()
{
    Args = Environment.GetCommandLineArgs(),
    ApplicationName = "Gastro Database",
    EnvironmentName = Environments.Development,
});

apiServer.Run();