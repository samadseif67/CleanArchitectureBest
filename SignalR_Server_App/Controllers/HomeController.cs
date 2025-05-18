using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalR_Server_App.Services;

namespace SignalR_Server_App.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private IHubContext<MessageHub, IMessageHubClient> messageHub;
        public HomeController(IHubContext<MessageHub, IMessageHubClient> _messageHub)
        {
            messageHub = _messageHub;
        }

        [HttpPost]
        public async Task<ActionResult> SendMag()
        {
            List<string> messages = new List<string>();
            messages.Add(DateTime.Now.ToString());
            messages.Add(DateTime.Now.ToString());
            messages.Add(DateTime.Now.ToString());
            await messageHub.Clients.All.SendOffersToUser(messages);
            return Ok("Sending msg");

        }




    }
}
