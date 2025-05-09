using Hangfire;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//************************************************************************
//Configuration AddHangfire
#region AddHangfire

builder.Services.AddHangfire(x =>
{
    x.UseSqlServerStorage(builder.Configuration["ConnectionStrings:ConnectionHangFire"]);
    x.UseSimpleAssemblyNameTypeSerializer();
    x.UseRecommendedSerializerSettings();
});

builder.Services.AddHangfireServer();

#endregion

//***************************************************************************

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//*****************************************************************************
//Configuration AddHangfire
#region AddHangfire
//برای اینکه بتوانیم از داشبورد هنگ فایر استفاده کنیم باید از آدرس زیر استفاده کنیم که خودمان تعیین میکنیم
app.UseHangfireDashboard(pathMatch:"/HangfireUrl");

#endregion

//*****************************************************************************




app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
