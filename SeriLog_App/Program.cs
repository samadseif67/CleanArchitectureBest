using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Serilog;
using SeriLog_App.Extensions;

var builder = WebApplication.CreateBuilder(args);

//****************************************************************************
//Serilog Configuration
builder.Host.UseSerilog((context, loggerConfig) => loggerConfig.ReadFrom.Configuration(context.Configuration));
 

//********************************************************************************

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//*****************************************************************************************
//Serilog Configuration
app.UseSerilogRequestLogging();
  

//*****************************************************************************************
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
