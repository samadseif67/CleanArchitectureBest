var builder = WebApplication.CreateBuilder(args);

//*******************************************************************************

builder.Services.AddHttpClient();

builder.Services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));
//*****************************************************************************

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || 1==1)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//***********************************************************************
app.UseCors("ApiCorsPolicy");

//**********************************************************************


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
