using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AUG30.Portfolio.Web.Filters
{
    public class MyExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            //throw new NotImplementedException();

            context.Result = new RedirectToRouteResult(
                                       new RouteValueDictionary
                                       {
                                    {"Area","" },
                                    {"controller", "home"},
                                    {"action", "Error"}
                                       }
                                   );
        }
    }
}
