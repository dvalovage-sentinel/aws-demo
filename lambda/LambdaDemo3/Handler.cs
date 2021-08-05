using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Amazon.S3;
using Amazon.S3.Model;

[assembly:LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]
namespace AwsDotnetCsharp
{
    public class Handler
    {
       public async Task<Response> Hello(Request request)
       {
         var s3Client = new AmazonS3Client();
         var s3Request = new ListObjectsV2Request
         {
           BucketName = "sentinel-serverless-demo1"
         };

         var list = await s3Client.ListObjectsV2Async(s3Request);
         return new Response($"Number  of files in the bucket: {list.S3Objects.Count}", request);
       }
    }

    public class Response
    {
      public string Message {get; set;}
      public Request Request {get; set;}

      public Response(string message, Request request){
        Message = message;
        Request = request;
      }
    }

    public class Request
    {
      public string Key1 {get; set;}
      public string Key2 {get; set;}
      public string Key3 {get; set;}
    }
}
