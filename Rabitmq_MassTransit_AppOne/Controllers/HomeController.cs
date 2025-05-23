using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using namespaceSendGmailCommand;

namespace Rabitmq_MassTransit_AppOne.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IBus _bus;
        private readonly IPublishEndpoint _publishEndpoint;
        public HomeController(IBus bus, IPublishEndpoint publishEndpoint)
        {
            _bus = bus;
            _publishEndpoint = publishEndpoint;
        }


        [HttpPost]
        public async Task<ActionResult> SendMasgForExchange(SendGmailCommand massage)
        {    
            var endpoint = await _bus.GetSendEndpoint(new Uri("exchange:my-exchange-Gmail"));
            await endpoint.Send(massage);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> SendMasgForQueue(SendGmailCommand massage)
        {
            
            var endpoint = await _bus.GetSendEndpoint(new Uri("queue:my-queue-Gmail"));
            await endpoint.Send(massage);

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> ReadMsg(SendGmailCommand massage)
        {
            await _publishEndpoint.Publish(massage);

            return Ok("1");
             
            
        }
    }
}
