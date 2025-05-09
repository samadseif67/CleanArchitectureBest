using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//*********************************************************************
builder.Services.AddApiVersioning(config =>
{
    config.AssumeDefaultVersionWhenUnspecified = true; 
    config.DefaultApiVersion = new ApiVersion(1, 0);
  
    config.ReportApiVersions = true;
    config.ApiVersionReader = ApiVersionReader.Combine( 
        new QueryStringApiVersionReader("api-version"),//از طریق QueryString دستزسی به عنوان مورد نظر را داریم
        new HeaderApiVersionReader("X-Version"),//از طریق هدر ریکوست ها میتوانیم مشخص کنیم
        new MediaTypeApiVersionReader("ver"));


});


//*********************************************************************




var app = builder.Build();

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
