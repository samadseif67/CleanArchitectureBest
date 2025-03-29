namespace HttpClientAndHttpClientFactory_App.Services
{
     
    public interface IRequestHttpClient
    {
        Task<string> Excute(string url);
    }


    public class RequestHttpClient : IRequestHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public RequestHttpClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _configuration = configuration;

            string BaseAddress = _configuration.GetSection("UrlApi:UrlGetPrice").Value;
            _httpClient.BaseAddress = new Uri(BaseAddress);

        }

        public async Task<string> Excute(string url)
        {
            var response = await _httpClient.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
