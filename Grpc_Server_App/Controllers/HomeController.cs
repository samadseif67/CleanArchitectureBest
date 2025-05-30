using Grpc_Server_App.Protos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Grpc_Server_App.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpPost]
        public ActionResult Test1()
        {
            GreeterService greeterService = new GreeterService();
            var result = greeterService.SayHello(new HelloRequest() { Name = "ali" }, null);
            return Ok(result);
        }




    }
}
