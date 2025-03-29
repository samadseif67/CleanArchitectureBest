using HttpClientAndHttpClientFactory_App.Services;

var builder = WebApplication.CreateBuilder(args);


//**********************************************************
builder.Services.AddScoped<IRequestHttpClient, RequestHttpClient>();
builder.Services.AddScoped<IRequestHttpClientFactory, RequestHttpClientFactory>();

builder.Services.AddHttpClient();//for HtttpClient
builder.Services.AddHttpClient("HttpClientFactoryConfig", x =>//For HttpClientFactory
{
    x.BaseAddress = new Uri(builder.Configuration.GetSection("UrlApi:UrlGetPrice").Value);
});







//***********************************************************




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
