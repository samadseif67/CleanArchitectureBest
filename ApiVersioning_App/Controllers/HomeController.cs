using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiVersioning_App.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiController]
    [ApiVersion(version:"1.0")]
    public class HomeController : ControllerBase
    {

        [HttpPost]
        public ActionResult Test1()
        {
            return Ok("Hi");
        }

         

        [HttpPost]
        [ApiVersion("1.2")]
        public ActionResult Test2()
        {
            return Ok("Hi version 2");
        }


    }
}
