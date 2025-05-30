using Grpc_Server_App.Protos;

var builder = WebApplication.CreateBuilder(args);

//*****************************Grpc***********************************


builder.Services.AddGrpc();






//******************************************************************

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//************************************Grpc*****************************************************
app.MapGrpcService<GreeterService>();

//*******************************************************************************************

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
