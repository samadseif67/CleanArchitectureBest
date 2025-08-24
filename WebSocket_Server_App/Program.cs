using System.Net;
using System.Net.WebSockets;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

//************************************************************************************************************************

app.MapGet("/send",async context =>
{
    if(context.WebSockets.IsWebSocketRequest) //اگر درخواستی بیاید
    {
        using (WebSocket webSocket=await context.WebSockets.AcceptWebSocketAsync())//ایجاد یک کانکشن
        {
            await Send(context, webSocket);
        }
    }
    else
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
    }
});

static async Task Send(HttpContext httpContext, WebSocket webSocket)
{
    var buffer = new byte[1024 * 4];
    WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), System.Threading.CancellationToken.None);//دریافت پیام از وب سوکت
    if (result != null)
    {
        while (!result.CloseStatus.HasValue)//اگر کلوز استتیوز مقدار نداشته باشد باید ادامه بدهیم
        {
            string msg = Encoding.UTF8.GetString(new ArraySegment<byte>(buffer, 0, result.Count));//پیام ها در کدام بافر نوشته شوند

            Console.WriteLine($"Client Says:{msg}");

            await webSocket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes($"server says:{DateTime.UtcNow}: ok {msg}")),
                result.MessageType, result.EndOfMessage,
                System.Threading.CancellationToken.None);
             
        }

    }
    await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, System.Threading.CancellationToken.None);
}
 
app.UseWebSockets();

//**********************************************************************************************************************
app.Run();
 