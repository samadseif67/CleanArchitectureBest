using Grpc.Core;

namespace Grpc_Server_App.Protos
{
    public class GreeterService : Greeter.GreeterBase
    {
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            HelloReply helloReply = new HelloReply();
            helloReply.Message = "Hello Grpc "+ request.Name;
            var result = Task.FromResult(helloReply);
            return result;
        }
    }
}
