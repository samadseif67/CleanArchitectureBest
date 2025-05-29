using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RateLimiting_App.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        [HttpPost]
        public ActionResult Test1()
        {
            return Ok("Test120");
        }


    }
}
