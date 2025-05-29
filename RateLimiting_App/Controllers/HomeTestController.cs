using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RateLimiting_App.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeTestController : Controller
    {
        [HttpPost]
        public ActionResult Test2()
        {
            return Ok("Test2");
        }
    }
}
