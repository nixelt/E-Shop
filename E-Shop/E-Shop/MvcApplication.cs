namespace E_Shop
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            DefaultModelBinder.ResourceClassKey = "Errors";
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Bootstrapper.Run();
        }

        protected void Application_Error()
        {
            var ex = Server.GetLastError();
            Logger.Log.Error(ex);
            Response.Clear();

            if (!(ex is HttpException httpException))
            {
                return;
            }

            string action;

            switch (httpException.GetHttpCode())
            {
                case 400:
                    action = "BadRequest";
                    break;
                case 403:
                    action = "Forbidden";
                    break;
                case 404:
                    action = "NotFound";
                    break;
                default:
                    action = "InternalServerError";
                    break;
            }

            // clear error on server
            Server.ClearError();

            Response.Redirect($"~/Error/{action}/");
        }
    }
}
