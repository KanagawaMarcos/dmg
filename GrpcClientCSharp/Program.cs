using System;
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Net.Client;
using System.Collections.Generic;

namespace GrpcClientCSharp
{
    class Program
    {
        static async Task Main(string[] arg)
        {
            var httpHandler = new HttpClientHandler();
            // @TODO figure out how to handle certificates properly with GRPC
            httpHandler.ServerCertificateCustomValidationCallback =
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            using var channel = GrpcChannel.ForAddress("https://localhost:5001",
                new GrpcChannelOptions { HttpHandler = httpHandler });
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(
                new HelloRequest { Name = "GreeterClient" }
            );
            Console.WriteLine("Greeting: " + reply.Message);
            //Repository.database.saveInspection("americanas", new List<int> { 1, 2, 3 });
            Repository.database.saveInspection("americanas");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
