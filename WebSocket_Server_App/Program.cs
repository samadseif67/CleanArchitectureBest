using System.Net;
using System.Net.WebSockets;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();

//***********************************************************************************************
var wsOptions = new WebSocketOptions { KeepAliveInterval = TimeSpan.FromSeconds(120) };
app.UseWebSockets(wsOptions);
app.Use(async (context, next) =>
{
    if (context.Request.Path == "/send")
    {
        if (context.WebSockets.IsWebSocketRequest)
        {
            using (WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync())
            {
                await Send(context, webSocket);
            }
        }
        else
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        }
        await Task.FromResult(next(context));
    }

});
static async Task Send(HttpContext httpContext, WebSocket webSocket)
{
    var buffer = new byte[1024 * 4];
    WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), System.Threading.CancellationToken.None);
    if (result != null)
    {
        while (!result.CloseStatus.HasValue)
        {
            string msg = Encoding.UTF8.GetString(new ArraySegment<byte>(buffer, 0, result.Count));
            Console.WriteLine($"Client Says:{msg}");
            await webSocket.SendAsync(new ArraySegment<byte>(Encoding.UTF8.GetBytes($"server says:{DateTime.UtcNow}: ok")),
                result.MessageType, result.EndOfMessage,
                System.Threading.CancellationToken.None);
            result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), System.Threading.CancellationToken.None);
            Console.WriteLine(result);
        }

    }
    await webSocket.CloseAsync(result.CloseStatus.Value,result.CloseStatusDescription,System.Threading.CancellationToken.None);
}

//*************************************************************************************************
