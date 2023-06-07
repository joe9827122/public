using Microsoft.AspNetCore.Mvc.Filters;

namespace StarterM
{
    public class MyLogAttribute :ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine(nameof(OnActionExecuted));
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine(nameof(OnActionExecuting));
        }
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine(nameof(OnResultExecuted));
        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            Console.WriteLine(nameof(OnResultExecuting));
        }
    }
}
