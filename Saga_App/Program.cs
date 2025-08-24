using Rebus.Config;
using Rebus.Routing.TypeBased;

var builder = WebApplication.CreateBuilder(args);



//********************************************************************************

builder.Services.AddRebus(rebus => rebus.Routing(r => r.TypeBased().MapAssemblyOf<Program>("eshop-queue"))
.Transport(t => t.UseRabbitMq(builder.Configuration.GetConnectionString("RabbitMq"), "eshop-queue"))
.Sagas(s => s.StoreInSqlServer(builder.Configuration.GetConnectionString("SqlServer"), dataTableName: "sagas", indexTableName: "SagaIndexes")),
onCreated: async bus =>
{
    await bus.Subscribe<OrderConfirmationEmailSent>();
    await bus.Subscribe<OrderPaymentRequrstSent>();

});


builder.Services.AutoRegisterHandlersFromAssemblyOf<Program>();



//*******************************************************************************




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
