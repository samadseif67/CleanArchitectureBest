using HttpClientAndHttpClientFactory_App.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HttpClientAndHttpClientFactory_App.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IRequestHttpClient _requestHttpClient;
        private readonly IRequestHttpClientFactory _requestHttpClientFactory;
        public HomeController(IRequestHttpClient requestHttpClient, IRequestHttpClientFactory requestHttpClientFactory)
        {
            _requestHttpClient = requestHttpClient;
            _requestHttpClientFactory = requestHttpClientFactory;
        }


        [HttpPost]
        public async Task<ActionResult> GetUseHttpClient()
        {
            try
            {
                var result = await _requestHttpClient.Excute("currentprice.json");
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }



        [HttpPost]
        public async Task<ActionResult> GetUseHttpClientFactory()
        {
            try
            {
                var result = await _requestHttpClientFactory.Excute("currentprice.json");
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



    }
}
