using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Docker_App.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        [HttpPost]
        public ActionResult Test1()
        {
            return Ok("hello hello Test1");
        }

        [HttpPost]
        public ActionResult Test2()
        {
            return Ok("hello hello Test2");
        }

    }
}
