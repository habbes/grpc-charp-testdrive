using System;
using Grpc.Core;

namespace GrpcTestDrive.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            RunServer();
        }

        static void RunServer()
        {
            int port = 50051;
            var server = new Grpc.Core.Server()
            {
                Services = { MyService.BindService(new MyServiceImpl()) },
                Ports = { new ServerPort("localhost", port, ServerCredentials.Insecure) }
            };

            server.Start();

            Console.WriteLine($"Server listening on port {port}");
            Console.WriteLine("Press any key to stop the server");
            Console.ReadKey();

            Console.WriteLine("Shutting down...");
            server.ShutdownAsync().Wait();
        }
    }
}
