namespace E_Shop.Filters
{
    using System;
    using System.Web.Mvc;

    public class ErrorHandler : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled || !filterContext.HttpContext.IsCustomErrorEnabled)
            {
                return;
            }

            Log(filterContext.Exception);
            switch (filterContext.Exception)
            {
                case ArgumentException _:
                case NullReferenceException _:
                    filterContext.Result = new RedirectResult("~/Error/NotFound");
                    break;
            }

            if (!filterContext.ExceptionHandled)
            {
                filterContext.Result = new RedirectResult("~/Error/InternalServerError");
            }

            filterContext.ExceptionHandled = true;
        }

        private static void Log(Exception exception)
        {
            var message = exception.InnerException == null
                              ? exception.Message
                              : exception.InnerException.Message;
            Logger.Log.Error(message, exception);
        }
    }
}