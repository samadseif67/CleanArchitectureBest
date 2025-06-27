using System.Text;

namespace Polly_Client_App
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;
        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task< List<int>> GetLstNumber()
        {
            List<int> lstNumber = new List<int>();  
           var result= await _httpClient.PostAsync("Home/TestHome", new StringContent("", Encoding.UTF8, "application/json"));
            lstNumber= await result.Content.ReadFromJsonAsync<List<int>>();
            return lstNumber;
        }

    }
}
