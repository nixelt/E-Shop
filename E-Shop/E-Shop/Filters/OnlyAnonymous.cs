namespace E_Shop.Filters
{
    using System.Web.Mvc;
    using System.Web.Mvc.Filters;

    public class OnlyAnonymous : FilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            var user = filterContext.HttpContext.User;
            if (!user.Identity.IsAuthenticated)
            {
                return;
            }

            var urlHelper = new UrlHelper(filterContext.RequestContext);
            var url = urlHelper.Action("Index", "Home");
            filterContext.Result = new RedirectResult(url);
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
        }
    }
}