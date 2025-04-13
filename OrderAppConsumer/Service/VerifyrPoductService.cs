
using Newtonsoft.Json;
using RestSharp;

namespace OrderAppConsumer.Service
{
    public interface IVerifyrPoductService
    {
        VerifyProductDto Verify(ProductDto productDto);
    }
    public class VerifyrPoductService : IVerifyrPoductService
    {


        private readonly IRestClient restClient;
        public VerifyrPoductService(IRestClient restClient)
        {
            this.restClient = restClient;
        }

        public VerifyProductDto Verify(ProductDto productDto)
        {
            var request = new RestRequest($"/api/Product/verify/{productDto.id}", Method.Get);
            RestResponse restResponse = restClient.Execute(request);
            var productRemote = JsonConvert.DeserializeObject<ProductVerifyOnServerProductDto>(restResponse.Content);

            return Verify(productDto, productRemote);
        }



        private VerifyProductDto Verify(ProductDto local, ProductVerifyOnServerProductDto remote)
        {
            if (local.Name == remote.Name)
            {
                return new VerifyProductDto
                {
                    IsCorrect = true
                };
            }
            else
            {
                return new VerifyProductDto
                {
                    Name = remote.Name,
                    IsCorrect = false
                };
            }
        }


    }







    public class VerifyProductDto
    {
        public string Name { get; set; }
        public bool IsCorrect { get; set; }
    }

    public class ProductVerifyOnServerProductDto
    {
        public Guid id { get; set; }
        public string Name { get; set; }
    }




    public class ProductDto
    {
        public Guid id { get; set; }
        public string Name { get; set; }
    }


}
