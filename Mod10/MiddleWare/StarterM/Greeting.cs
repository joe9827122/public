using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace StarterM
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Greeting
    {
        private readonly RequestDelegate _next;

        public Greeting(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.StartsWithSegments("/sayhello"))
            {
                await httpContext.Response.WriteAsync("Hello\n");
            }
            if (httpContext.Request.Path.StartsWithSegments("/sayhi"))
            {
                await httpContext.Response.WriteAsync("Hi\n");
            }

            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class GreetingExtensions
    {
        public static IApplicationBuilder UseGreeting(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Greeting>();
        }
    }
}
