using GKS.Web;
using Microsoft.Extensions.Hosting;

namespace GKS.Gastro;

public class DatabaseApiServer : ApiServer
{
    public override void InitServices(IHostApplicationBuilder builder)
    {
        base.InitServices(builder);
    }
}