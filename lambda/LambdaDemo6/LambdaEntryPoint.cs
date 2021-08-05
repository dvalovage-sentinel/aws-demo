using Microsoft.AspNetCore.Hosting;

namespace MySpace
{
    /// <summary>
    /// The AWS Lambda entry point should inherit from APIGatewayHttpApiV2ProxyFunction for most new API's.
    /// If the older API Gateway REST API is required, inherit from APIGatewayProxyFunction instead.
    /// 
    /// Current differences between the HTTP and REST API's:
    /// https://docs.aws.amazon.com/apigateway/latest/developerguide/http-api-vs-rest.html
    /// </summary>
    public class LambdaEntryPoint : Amazon.Lambda.AspNetCoreServer.APIGatewayHttpApiV2ProxyFunction
    {
        protected override void Init(IWebHostBuilder builder)
        {
            builder.UseStartup<Startup>();
        }
    }
}