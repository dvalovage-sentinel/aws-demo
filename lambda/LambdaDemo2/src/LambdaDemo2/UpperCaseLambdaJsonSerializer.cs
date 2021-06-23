using Amazon.Lambda.Core;
using System.IO;
using System.Text.Json;

namespace LambdaDemo2
{
    public class UpperCaseLambdaJsonSerializer : ILambdaSerializer
    {
        public T Deserialize<T>(Stream requestStream)
        {
            using (var reader = new StreamReader(requestStream))
            {
                var message = reader.ReadToEnd().ToLower();
                var obj = JsonSerializer.Deserialize<T>(message);
                return obj;
            }
        }

        public void Serialize<T>(T response, Stream responseStream)
        {
            using (var writer = new Utf8JsonWriter(responseStream))
            {
                JsonSerializer.Serialize(writer, response);
            }
        }
    }
}
