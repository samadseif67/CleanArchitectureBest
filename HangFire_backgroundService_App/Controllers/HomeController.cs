using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HangFire_backgroundService_App.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        [HttpPost]
        public string FireAndForgetJob()//این جاب یکبار انجام میشود
        {
            var jobId = BackgroundJob.Enqueue(() => Console.WriteLine("hello word ali fire and forget job"));
            return jobId;
        }

        [HttpPost]
        public string DealyJob()//بعد از مدت زمان مشخص شده اجرا شود
        {
            var jobId = BackgroundJob.Schedule(() => Console.WriteLine(""), TimeSpan.FromSeconds(2));
            return jobId;
        }


        [HttpPost]

        public string ContinousJob()//ابتدا جاب پدر اجرا شود سپس جاب فرزند
        {
            var parentJobId = BackgroundJob.Enqueue(() => Console.WriteLine("first job"));
            BackgroundJob.ContinueJobWith(parentJobId, () => Console.WriteLine("secend job"));//این جاب در صورتی انجام میشود که جاب بالا پدر انجام شده باشد
            return parentJobId;
        }


        [HttpPost]
        public string RecurringJobs()//این جاب بصورت هفته ای یا زمان مشخصی اجرا میشود
        {
            
           RecurringJob.AddOrUpdate("RecurringJobTest1", () => Console.WriteLine("Hi RecurringJob"), Cron.Weekly());
            return "RecurringJob Ending";
        }


    }
}
