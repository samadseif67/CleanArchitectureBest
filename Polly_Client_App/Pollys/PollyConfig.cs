using Polly;
using Polly.Extensions.Http;

namespace Polly_Client_App.Pollys
{
    public  class PollyConfig
    {

         
      public static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .CircuitBreakerAsync(
                    handledEventsAllowedBeforeBreaking: 3,//بعد از سه بار تلاش کردن اگر جواب نگرفتیم تا 20 ثانیه دیگر نتوانیم به سرور درخواست بدهیم
                    durationOfBreak: TimeSpan.FromSeconds(20),
                    onBreak: (exception, breakDelay) =>
                    {
                        Console.WriteLine($"Circuit broken: {exception.Result}");
                    },
                    onReset: () =>
                    {
                        Console.WriteLine("Circuit reset");
                    },
                    onHalfOpen: () =>
                    {
                        Console.WriteLine("Circuit in half-open state");
                    });
        }


      
        public static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(5, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))// Retry two times after delay 
                , (_,waitingtime) =>
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine($"polly retry {DateTime.Now.ToShortTimeString()}");
                    Console.ResetColor();

                });  

        }






    }
}
