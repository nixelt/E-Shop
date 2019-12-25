namespace E_Shop.Areas.Admin.Controllers
{
    using System.Web.Mvc;

    using ViewModels.LogViewModels;
    using Service;
    using E_Shop.ViewModels.PagerViewModel;

    [Authorize(Roles = "Admin")]
    public class LogController : Controller
    {
        private readonly ILogService _logService;

        public LogController(ILogService logService)
        {
            _logService = logService;
        }

        // GET: Admin/Log
        public ActionResult Index()
        {
            var logs = _logService.GetLogs();
            var model = PagerViewModelHelper<LogViewModel>.ToPagerViewModel(logs);
            return View(model);
        }

        // GET: Admin/Log/GetLogs
        public ActionResult GetLogs(int? logLevel, int page = 1)
        {
            var logs = _logService.GetLogs(logLevel);
            var model = PagerViewModelHelper<LogViewModel>.ToPagerViewModel(logs, page);
            return PartialView("_Logs", model);
        }
    }
}