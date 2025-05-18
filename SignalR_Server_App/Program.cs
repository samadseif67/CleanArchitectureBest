using SignalR_Server_App.Services;

var builder = WebApplication.CreateBuilder(args);

//**********************************************************************************************
//AddSignalR

builder.Services.AddSignalR();
builder.Services.AddCors(options => {
    options.AddPolicy("CORSPolicy", builder => builder.AllowAnyMethod().AllowAnyHeader().AllowCredentials().SetIsOriginAllowed((hosts) => true));
});




//*******************************************************************************************

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//*******************************************************************************************
 

//********************************************************************************************

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
//***************************************************************************************
//AddSignalR

app.UseCors("CORSPolicy");
app.UseRouting();
app.UseEndpoints(endpoints => {
    endpoints.MapControllers();
    endpoints.MapHub<MessageHub>("/offers");
});


//****************************************************************************************

app.MapControllers();

app.Run();
