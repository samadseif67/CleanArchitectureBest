using Hangfire;
using HangFire_App.JobServices;

var builder = WebApplication.CreateBuilder(args);

//*******************************Hangfire***************************************
builder.Services.AddSingleton<DynamicJobExecutor>();
builder.Services.AddScoped<RecurringJobScheduler>();
builder.Services.AddTransient<HangFire_App.JobServices.MyJobs>();

//******************************************************************************

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//************************************Hangfire**********************************

builder.Services.AddHangfire(config =>
    config.UseSimpleAssemblyNameTypeSerializer()
          .UseRecommendedSerializerSettings()
          .UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnectionHangfire")));

builder.Services.AddHangfireServer(); // برای اجرای سرویس Hangfire

//*******************************************************************************

var app = builder.Build();



//*******************************Hangfire***************************************
 
app.UseHangfireDashboard(); // داشبورد Hangfire
app.UseHangfireServer();
//RecurringJob.AddOrUpdate<MyJobs>(x => x.MyJobMethod(), Cron.Daily(11, 25),TimeZoneInfo.Local);//هر زوز در زمان مشخص ساعت ده این کار را انجام بده

// فراخوانی RecurringJobScheduler
using (var scope = app.Services.CreateScope())
{
    var scheduler = scope.ServiceProvider.GetRequiredService<RecurringJobScheduler>();
    scheduler.ScheduleJobs();
}


//*/ 5 9 * *1 - 5 → هر 5 دقیقه بین ساعت 9 صبح، از روز شنبه تا پنج‌شنبه
//0 0/2 * * * → هر 2 ساعت یک‌بار
//0 0 1 1 * → هر سال در اول فروردین ساعت 12 شب

// RecurringJob.AddOrUpdate(() => MyJobMethod(), "0 10 * * *");  هر روز ساعت 10 صبح:
//RecurringJob.AddOrUpdate(() => MyJobMethod(), "0 21 * * 2");   هر دوشنبه ساعت 9 شب:
//RecurringJob.AddOrUpdate(() => MyJobMethod(), "0 8 15 * *"); هر 15 ام ماه ساعت 8 صبح:
//RecurringJob.AddOrUpdate(() => MyJobMethod(), "0 0 * * 6"); هر روز جمعه ساعت 12 شب:


//┌───────────── دقیقه(0 - 59)
//│ ┌───────────── ساعت(0 - 23)
//│ │ ┌───────────── روز ماه(1 - 31)
//│ │ │ ┌───────────── ماه(1 - 12)
//│ │ │ │ ┌───────────── روز هفته(0 - 6) (شنبه = 0 یا 7)
//│ │ │ │ │
//│ │ │ │ │
//*****command to execute

//*********************************************************************




if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
