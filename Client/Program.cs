using System;
using System.Threading.Tasks;
using Grpc.Core;
using GrpcTestDrive;

namespace GrpcTestDrive.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
            var client = new MyService.MyServiceClient(channel);

            RunClient(client).Wait();

            channel.ShutdownAsync().Wait();
        }

        static async Task RunClient(MyService.MyServiceClient client)
        {
            var requests = new MyRequest[]
            {
                new MyRequest() { Message = "Request 1" },
                new MyRequest() { Message = "Request 2" }
            };

            foreach (var request in requests)
            {
                var reply = await client.SendRequestAsync(request);
                Console.WriteLine($"Client received response: '{reply.Message}', '{reply.Foo}'");
            }
        }
    }
}
