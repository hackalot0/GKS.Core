using Microsoft.AspNetCore.Builder;

namespace GKS.Web;

public interface IApiServer
{
    WebApplication? WebApp { get; }

    void Run();
    Task? RunAsync(CancellationToken token = default);
}