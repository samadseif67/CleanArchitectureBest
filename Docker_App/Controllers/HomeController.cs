using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Docker_App.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;
        public HomeController(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _configuration = configuration;
        }

        [HttpPost]
        public ActionResult Test1()
        {
            var result = Guid.NewGuid();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Test2()
        {
            try
            {
                var urlApiRandom = _configuration.GetValue<string>("UrlApi:ApiRandom");
                _client.BaseAddress = new Uri(urlApiRandom);
                StringContent httpContent = new StringContent("", System.Text.Encoding.UTF8, "application/json");
                var result = await _client.PostAsync("Home/Test1", httpContent);
                var guid = result.Content.ReadFromJsonAsync<string>().Result;
                return Ok(guid);
            }
            catch (Exception ex)
            {

                return Ok(ex.Message);
            }
        }





        [HttpPost]
        public async Task<ActionResult> Test3()
        {
            try
            {
                var urlApiRandom = _configuration.GetValue<string>("UrlApi:ApiRandomInternal");
                _client.BaseAddress = new Uri(urlApiRandom);
                StringContent httpContent = new StringContent("", System.Text.Encoding.UTF8, "application/json");
                var result = await _client.PostAsync("Home/Test1", httpContent);
                var guid = result.Content.ReadFromJsonAsync<string>().Result;
                return Ok(guid);
            }
            catch (Exception ex)
            {

                return Ok(ex.Message);
            }
        }




    }
}
