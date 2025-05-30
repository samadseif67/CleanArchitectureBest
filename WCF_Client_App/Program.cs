using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCF_Server_App;

namespace WCF_Client_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<ICalculatorService> factory = new ChannelFactory<ICalculatorService>(
            new BasicHttpBinding(),
            new EndpointAddress("http://localhost:8080/CalculatorService"));
            ICalculatorService proxy = factory.CreateChannel();
            int result = proxy.Add(5, 3);
            Console.WriteLine($"Result: {result}");
        }
    }
}
