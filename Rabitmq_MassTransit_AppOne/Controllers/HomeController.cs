using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rabitmq_MassTransit_AppOne.Modals;

namespace Rabitmq_MassTransit_AppOne.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IBus _bus;
        public HomeController(IBus bus)
        {
            _bus = bus;
        }


        [HttpPost]
        public async Task<ActionResult> SendMasg(SendGmailCommand massage)
        {
           await _bus.Publish(massage);
            return Ok();
        }



    }
}
