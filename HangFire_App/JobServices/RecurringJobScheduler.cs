// Services/RecurringJobScheduler.cs

using Hangfire;
using HangFire_App.JobServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

public class RecurringJobScheduler
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<RecurringJobScheduler> _logger;

    public RecurringJobScheduler(IServiceProvider serviceProvider, ILogger<RecurringJobScheduler> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    public void ScheduleJobs()
    {
        using (var scope = _serviceProvider.CreateScope())
        {
             
            List<ScheduledJob> jobs = new List<ScheduledJob>();

            //HangFire_App.JobServices.MyJobs  name space
            //HangFire_App ProjectName

            jobs.Add(new ScheduledJob()
            {
                ClassName = "HangFire_App.JobServices.MyJobs, HangFire_App",
                MethodName = "MyJobMethod2",
                ExecutionTime = new TimeSpan(14, 30, 10)
            });


            jobs.Add(new ScheduledJob()
            {
                ClassName = "HangFire_App.JobServices.MyJobs, HangFire_App",
                MethodName = "MyJobMethod2",
                ExecutionTime = new TimeSpan(14, 31, 10)
            });


            jobs.Add(new ScheduledJob()
            {
                ClassName = "HangFire_App.JobServices.MyJobs, HangFire_App",
                MethodName = "MyJobMethod2",
                ExecutionTime = new TimeSpan(14, 32, 10)
            });

            var executor = scope.ServiceProvider.GetRequiredService<DynamicJobExecutor>();

            foreach (var job in jobs)
            {
                try
                {
                    var hour = job.ExecutionTime.Hours;
                    var minute = job.ExecutionTime.Minutes;
                  
                    var localJob = job;
                    var jobId = $"{localJob.ClassName}.{localJob.MethodName}_{hour}_{minute}";
                    
                    RecurringJob.AddOrUpdate(
                        jobId,
                        () => executor.Execute(job.ClassName, job.MethodName),
                        Cron.Daily(hour, minute), // یا Cron.MinuteInterval(1) برای تست
                        TimeZoneInfo.Local
                        );

                    _logger.LogInformation("Scheduled job: {JobId} at {Time}", jobId, job.ExecutionTime);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error scheduling job: {JobId}", job.ClassName + "." + job.MethodName);
                }
            }
        }
    }
}