using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GrpcTestDrive;

namespace GrpcTestDrive.Server
{
    class MyServiceImpl: MyService.MyServiceBase
    {
        public override Task<MyReply> SendRequest(MyRequest request, Grpc.Core.ServerCallContext context)
        {
            Console.WriteLine($"Server received message '{request.Message}'");
            var reply = new MyReply();
            reply.Message = $"Received message: {request.Message}";
            reply.Foo = new Random().Next();
            return Task.FromResult(reply);
        }
    }
}
