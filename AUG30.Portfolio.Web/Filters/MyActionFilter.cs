using Microsoft.AspNetCore.Mvc.Filters;

namespace AUG30.Portfolio.Web.Filters
{
    public class MyActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //
           // context.HttpContext.Request.Host;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //
        }
    }
}
