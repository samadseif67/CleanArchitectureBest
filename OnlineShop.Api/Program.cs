using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.ResponseCompression;
using Newtonsoft.Json.Serialization;
using OnlineShop.Application;
using OnlineShop.Persistence;
using PuppeteerSharp;
using System.Web.Mvc;

var builder = WebApplication.CreateBuilder(args);

//*************************************************************

builder.Services.ApplicationConfig();
builder.Services.PersistenceConfig(builder.Configuration);



//**********************************************************

//builder.Services.AddControllers();
builder.Services.AddControllers(options => { options.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>(); }//برای اینکه بتواند خروجی null برگرداند
 ).AddNewtonsoftJson(options =>
 {
     options.SerializerSettings.ContractResolver = new DefaultContractResolver(); // غیرفعال کردن camelCase   //خروجی در صورتی که حروف بزرگ باشد همان حروف بزرگ نمایش داده میشود
 });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//*************************************************************************
//برای کاهش دادن حجم اطلاعات  از سمت سرور به سمت کلاینت

builder.Services.AddResponseCompression(x =>
{
    x.EnableForHttps = true;
    x.Providers.Add<BrotliCompressionProvider>();
    x.Providers.Add<GzipCompressionProvider>();
});

builder.Services.Configure<BrotliCompressionProviderOptions>(x =>
{
    x.Level = System.IO.Compression.CompressionLevel.Optimal;
});
builder.Services.Configure<GzipCompressionProviderOptions>(x =>
{
    x.Level = System.IO.Compression.CompressionLevel.Optimal;
});



//************************************************************
 


//***********************************************************

var app = builder.Build();


//***********************************************

app.UseResponseCompression();//برای کاهش دادن حجم اطلاعات  از سمت سرور


//*************************************************



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
