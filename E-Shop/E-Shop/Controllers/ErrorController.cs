namespace E_Shop.Controllers
{
    using System.Web.Mvc;

    public class ErrorController : Controller
    {
        // GET: /Error/BadRequest
        public ActionResult BadRequest()
        {
            Response.StatusCode = 400;
            return View();
        }

        // GET: /Error/Forbidden
        public ActionResult Forbidden()
        {
            Response.StatusCode = 403;
            return View();
        }

        // GET: /Error/NotFound
        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            return View();
        }

        // GET: /Error/InternalServerError
        public ActionResult InternalServerError()
        {
            Response.StatusCode = 500;
            return View();
        }
    }
}