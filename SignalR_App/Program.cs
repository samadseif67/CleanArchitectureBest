using SignalR_App.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();


//*************************************************************

builder.Services.AddSignalR();



//*************************************************************

var app = builder.Build();

 
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


//**********************************************************************
//SignalR

app.MapHub<RealTimeHub>("/realtimehub");


//**********************************************************************

app.Run();
