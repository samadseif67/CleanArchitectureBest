using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiVersioning_App.Controllers
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/{v:apiVersion}/employee")]
    public class EmployeeV2Controller : ControllerBase
    {

        [HttpGet]
        public ActionResult Get()
        {
            return Ok("Version 2");
        }
         
    }
}
