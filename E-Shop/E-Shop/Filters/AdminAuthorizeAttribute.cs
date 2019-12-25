namespace E_Shop.Filters
{
    using System.Web;
    using System.Web.Mvc;

    public class AdminAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var routeData = httpContext.Request.RequestContext.RouteData;
            var area = routeData.DataTokens["area"];
            var user = httpContext.User;
            if (area != null && area.ToString() == "Admin")
            {
                if (!user.Identity.IsAuthenticated)
                {
                    return false;
                }

                if (!user.IsInRole("Manager") && !user.IsInRole("Admin"))
                {
                    return false;
                }
            }

            return true;
        }
    }
}