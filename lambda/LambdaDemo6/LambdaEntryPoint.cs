using Microsoft.AspNetCore.Hosting;

namespace MySpace
{
    public class LambdaEntryPoint : Amazon.Lambda.AspNetCoreServer.APIGatewayProxyFunction// APIGatewayHttpApiV2ProxyFunction?
    {
        protected override void Init(IWebHostBuilder builder)
        {
            builder
                .UseStartup<Startup>();
        }
    }
}