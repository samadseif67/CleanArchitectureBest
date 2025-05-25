using Serilog.Context;

namespace SeriLog_App.Extensions
{
    public class RequestLogContextMiddleware
    {

        private readonly RequestDelegate _next;
        public RequestLogContextMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task InvokeAsync(HttpContext context)
        {
            using (LogContext.PushProperty("CollerationID",context.TraceIdentifier))
            {
                return _next(context);
            }
        }
         
    }
}
