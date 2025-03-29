using System.Net.Http;

namespace HttpClientAndHttpClientFactory_App.Services
{
    public interface IRequestHttpClientFactory
    {
        Task<string> Excute(string url);
    }
    public class RequestHttpClientFactory : IRequestHttpClientFactory
    {
        private readonly IHttpClientFactory _httpclientFacory;
        public RequestHttpClientFactory(IHttpClientFactory httpclientFacory)
        {
            _httpclientFacory = httpclientFacory;
        }

        public async Task<string> Excute(string url)
        {
           using var client= _httpclientFacory.CreateClient("HttpClientFactoryConfig");
           var response=  await client.GetAsync(url);
           return await  response.Content.ReadAsStringAsync();
        }
    }
}
