using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AUG30.Portfolio.Web.Filters
{
    public class MVCAuthorizationFilter : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //
        }
    }
}
