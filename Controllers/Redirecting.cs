using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Save__plan_your_trips.Controllers
{
    public class RedirectToAuthenticatedUserHomePageAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (filterContext.HttpContext.User.Identity!.IsAuthenticated)
                filterContext.Result = new RedirectToActionResult("Index", "Home", null);
        }
    }
}