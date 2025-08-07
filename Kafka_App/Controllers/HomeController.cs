using Kafka_App.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kafka_App.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ProducerService _producerService;
        public HomeController(ProducerService producerService)
        {
            _producerService = producerService;
        }

        [HttpPost]
        public async Task<ActionResult> SendMsg(CancellationToken cancellationToken)
        {
            await _producerService.ProducerAsync(cancellationToken);
            return Ok(Task.FromResult("send msg"));
        }


    }
}
