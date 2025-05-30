using System;
using System.ServiceModel;
using WCF_Server_App;

class Program
{
    static void Main()
    {
        using (ServiceHost host = new ServiceHost(typeof(CalculatorService)))
        {
            host.Open();
            Console.WriteLine("Service is running...");
            Console.ReadLine();
            host.Close();
        }
    }
}