using Microsoft.AspNetCore.Mvc.Filters;

namespace AUG30.Portfolio.Web.Filters
{
    public class MyResultFilter : IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            // throw new NotImplementedException();
            context.HttpContext.Response.Headers.Add("my-Accept-Encoding", "gzip, deflate, br, binod");
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            //throw new NotImplementedException();
            context.HttpContext.Response.Headers.Add("my-Accept-Encoding", "gzip, deflate, br, binod");
        }
    }
}
