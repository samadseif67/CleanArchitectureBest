using OrderAppConsumer.Service;
using OrderAppConsumerTest_BetweenTwoProject.ClassFixture;
using PactNet.Matchers;
using PactNet.Mocks.MockHttpService;
using PactNet.Mocks.MockHttpService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAppConsumerTest_BetweenTwoProject.Service
{
    public class ConsumerPactTests : IClassFixture<ConsumerPactClassFixture>
    {
        private IMockProviderService _mockProviderService;
        private string _mockProviderServiceBaseUri;

        public ConsumerPactTests(ConsumerPactClassFixture fixture)
        {
            _mockProviderService = fixture.MockProviderService;
            _mockProviderService.ClearInteractions(); //NOTE: Clears any previously registered interactions before the test is run
            _mockProviderServiceBaseUri = fixture.MockProviderServiceBaseUri;
        }


        [Fact]
        public void VerifyrPoductService_Verify()
        {
            // Arange
          
            Guid guid = Guid.NewGuid();
            //کد پایین باعث ایجاد یک سرور میشود 
            //با مسیر پایین
            //$"/api/Product/verify/{guid.ToString()}",
            //و با خروجی پایین که انتظار داریم سرور اطلاعات را برگرداند
            //Body = Match.Type(new//وقتی از این قسمت استفاده میکنیم یعنی باید ساختار داخلی زیر را داشته باشد 
                                    //{//حروجی آبجکتی که قراراست وب سرویس به ما برگرداند
                                     //   id = guid.ToString(),
                                      //  name = "hello ok"
                                   // })



            _mockProviderService.Given("There is correct data")
                                .UponReceiving("product information return")
                                .With(new ProviderServiceRequest
                                {
                                    Method = HttpVerb.Get,
                                    Path = $"/api/Product/verify/{guid.ToString()}",
                                   // Query = " "//query string 
                                })
                                .WillRespondWith(new ProviderServiceResponse
                                {
                                    Status = 200,
                                    Headers = new Dictionary<string, object>
                                    {
                                { "Content-Type", "application/json; charset=utf-8" }
                                    },
                                    Body = Match.Type(new//وقتی از این قسمت استفاده میکنیم یعنی باید ساختار داخلی زیر را داشته باشد 
                                    {//حروجی آبجکتی که قراراست وب سرویس به ما برگرداند
                                        id = guid.ToString(),
                                        name = "hello ok"
                                    })
                                });


            //Act
            IVerifyrPoductService VerifyrPoductService = new VerifyrPoductService(new RestSharp.RestClient(_mockProviderServiceBaseUri));
            var result = VerifyrPoductService.Verify(new ProductDto()
            {
                id = guid,
                Name = "hello ok1"
            });


            //Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Name);

        }


    }
}
