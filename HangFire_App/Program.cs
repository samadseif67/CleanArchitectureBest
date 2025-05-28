using Hangfire;
using HangFire_App.JobServices;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//************************************Hangfire**********************************

builder.Services.AddHangfire(config =>
    config.UseSimpleAssemblyNameTypeSerializer()
          .UseRecommendedSerializerSettings()
          .UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHangfireServer(); // برای اجرای سرویس Hangfire

//***********************************************************************

var app = builder.Build();



//*******************************Hangfire***************************************

app.UseHangfireDashboard(); // داشبورد Hangfire
RecurringJob.AddOrUpdate<MyJobs>(x => x.MyJobMethod(), Cron.Daily(10, 0));//هر زوز در زمان مشخص ساعت ده این کار را انجام بده


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
