namespace E_Shop.Filters
{
    using System.Web.Mvc;

    public class Authorize : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Controller.TempData["Msg"] = "Недостаточно прав. Войдите, чтобы получить доступ";
            filterContext.Result = new HttpUnauthorizedResult();
        }
    }
}