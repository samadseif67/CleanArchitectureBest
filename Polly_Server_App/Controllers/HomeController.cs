using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Polly_Server_App.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        [HttpPost]
        public ActionResult TestHome()
        {
            List<string> Lst = new List<string>() { "10", "20", "30", "40" };
            return Ok(Lst);
        }




    }
}
