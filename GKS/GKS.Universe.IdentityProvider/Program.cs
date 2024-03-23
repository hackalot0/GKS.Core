using GKS.Universe;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

var apiServer = new IdentityProviderApiServer();

apiServer.Init(new WebApplicationOptions()
{
    Args = Environment.GetCommandLineArgs(),
    ApplicationName = "Identity Provider",
    EnvironmentName = Environments.Development,
});

apiServer.Run();