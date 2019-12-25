namespace E_Shop
{
    using System.Web.Mvc;

    using Filters;

    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ErrorHandler());
            filters.Add(new AdminAuthorizeAttribute()); 
        }
    }
}
