namespace E_Shop.Areas.Admin.Controllers
{
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Order");
        }
    }
}