using System;
using Amazon.Lambda.Core;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]
namespace LambdaDemo1
{
    public class EntryClass
    {
        public Response Handler(Request request)
        {
            // Logs to CloudWatch
            Console.WriteLine($"Message: {request.Message}");

            return new Response { RequestId = request.RequestId };
        }
    }
}
