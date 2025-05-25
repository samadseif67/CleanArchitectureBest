using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SeriLog_App.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]   
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        [HttpPost]
        public ActionResult Test1()
        {
            _logger.LogInformation($"log is date time{DateTime.Now}");
            return Ok();
        }




    }
}
