using Grpc.Net.Client;
using Grpc_Server_App.Protos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Grpc_Client_App.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> GrpcClient()
        {
       
              // Set up the gRPC channel to connect to the server
            using var channel = GrpcChannel.ForAddress("https://localhost:7272");
            
            
            // Create a client for the Greeter service
            var client = new Greeter.GreeterClient(channel);

            // Call the SayHello method with a HelloRequest
            var reply = await client.SayHelloAsync(new HelloRequest { Name = "Scott" });

            return Ok(reply);

        }


    }
}
