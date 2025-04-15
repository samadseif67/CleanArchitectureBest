using PactNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PactNet.Mocks.MockHttpService;
namespace OrderAppConsumerTest_BetweenTwoProject.ClassFixture
{
    //https://github.com/pact-foundation/pact-workshop-dotnet-core-v1
    public class ConsumerPactClassFixture : IDisposable
    {
        public IPactBuilder PactBuilder { get; private set; }
        public IMockProviderService MockProviderService { get; private set; }

        public int MockServerPort { get { return 1002; } }
        public string MockProviderServiceBaseUri { get { return String.Format("http://localhost:{0}", MockServerPort); } }


        public ConsumerPactClassFixture()
        {
            var pactConfig = new PactConfig
            {
                SpecificationVersion = "2.0.0",
                PactDir = @"c:\pacts",//در این مسیر فایل قرارداد ایجاد میشود
                LogDir = @".\pact_logs"
            };
            PactBuilder = new PactBuilder(pactConfig);//باعث میشود که فایل جی سان در مسیر بالا ساخته شود

            PactBuilder.ServiceConsumer("Consumer")
                       .HasPactWith("Provider");
            MockProviderService = PactBuilder.MockService(MockServerPort);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // This will save the pact file once finished.
                    PactBuilder.Build();
                }

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }
        #endregion

    }
}
