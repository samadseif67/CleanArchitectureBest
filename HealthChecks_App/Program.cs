using HealthChecks.UI.Client;
using HealthChecks.UI.Configuration;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

//***************************************AddHealthChecks*********************************************
//https://github.com/Xabaril/AspNetCore.Diagnostics.HealthChecks      

builder.Services.AddHealthChecks().AddSqlServer(builder.Configuration.GetConnectionString("DBConnectionStrings"));

// افزودن سرویس HealthChecks UI
builder.Services.AddHealthChecksUI(options =>
{
    options.SetEvaluationTimeInSeconds(60); // زمان ارزیابی سلامت سرویس ها (ثانیه)
    options.MaximumHistoryEntriesPerEndpoint(50); // حداکثر تعداد لاگ های ذخیره شده
    options.AddHealthCheckEndpoint("API Health", "/health"); // آدرس endpoint سلامت
})
.AddInMemoryStorage(); // برای ذخیره سازی نتایج (در این مثال از حافظه موقت استفاده شده)

//*************************************************************************************

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//*********************************************AddHealthChecks********************************************

//app.MapHealthChecks("/api/health");
app.UseHealthChecks("/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,//باعث میشود ui بهتری ارائه شود
});
//برای نمایش ظاهری جی سان

app.UseHealthChecksUI(options =>
{
    options.UIPath = "/health-ui"; // مسیر دلخواه برای UI
    options.ApiPath = "/health-api"; // مسیر API برای UI
});
 
 
//****************************************************************************************
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();




app.Run();
