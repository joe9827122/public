using Microsoft.AspNetCore.Mvc.Filters;

namespace StarterM
{
    public class MyLogAttritube:ActionFilterAttribute, IDisposable
    {
        readonly ILogger<MyLogAttritube> _logger;

        public MyLogAttritube(ILogger<MyLogAttritube> logger)
        {
            _logger = logger;
        }

        public void Dispose()
        {
            _logger.LogWarning($"{nameof(MyLogAttritube)}: {nameof(Dispose)}");
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.RouteData.Values["controller"];
            var action = context.RouteData.Values["action"];
            var id = context.RouteData.Values["id"];

            _logger.LogWarning($"{controller}/{action}/{id}");
        }
    }
}
