namespace E_Shop.Areas.Admin.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    using AutoMapper;

    using Data.Identity;

    using E_Shop.ViewModels.PagerViewModel;

    using Microsoft.AspNet.Identity;

    using Model;

    using Service;

    using ViewModels.UserViewModels;

    public class CustomerController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ApplicationUserManager _userManager;

        public CustomerController(ApplicationUserManager userManager, IOrderService orderService)
        {
            _userManager = userManager;
            _orderService = orderService;
        }

        // GET: Admin/Customer/Index
        public ActionResult Index()
        {
            var customers = _userManager.Users.ToList();
            var model = PagerViewModelHelper<UserViewModel>.ToPagerViewModel(customers);
            return View(model);
        }

        // GET: Admin/Customer/GetUsers
        public ActionResult GetUsers(bool onlyBlocked = false, int page = 1)
        {
            var customers = _userManager.GetUsers(onlyBlocked);
            var model = PagerViewModelHelper<UserViewModel>.ToPagerViewModel(customers, page);
            return PartialView("_Customers", model);
        }

        // GET: Admin/Customer/Details
        public ActionResult Details(string id, string msg = null)
        {
            ViewData["Message"] = msg;
            var user = _userManager.FindByIdAsync(id).Result;
            if (user == null)
            {
                return RedirectToAction("NotFound", "Error", new { Area = string.Empty });
            }

            user.Orders = _orderService.GetOrders(customerId: user.Id);
            var model = Mapper.Map<User, DetailsUserViewModel>(user);
            model.IsBlocked = user.LockoutEndDateUtc > DateTime.Now;
            return View(model);
        }

        // POST: Admin/Customer/Block
        [HttpPost]
        public async Task<ActionResult> Block(string id)
        {
            var user = _userManager.FindByIdAsync(id).Result;
            if (user == null)
            {
                return RedirectToAction("NotFound", "Error", new { Area = string.Empty });
            }

            if (_userManager.IsInRole(id, "Manager"))
            {
                return RedirectToAction("Details", new { id, msg = "Пользователь является менеджером" });
            }

            await _userManager.SetLockoutEnabledAsync(user.Id, true).ConfigureAwait(false);
            await _userManager.SetLockoutEndDateAsync(user.Id, DateTimeOffset.MaxValue).ConfigureAwait(false);
            await _userManager.UpdateSecurityStampAsync(user.Id).ConfigureAwait(false);
            Logger.Log.Info($"{User.Identity.Name} заблокировал пользователя {user.UserName}");
            return RedirectToAction("Details", new { id });
        }

        // POST: Admin/Customer/Unblock
        [HttpPost]
        public async Task<ActionResult> Unblock(string id)
        {
            var user = _userManager.FindByIdAsync(id).Result;
            if (user == null)
            {
                return RedirectToAction("NotFound", "Error", new { Area = string.Empty });
            }

            await _userManager.SetLockoutEndDateAsync(user.Id, DateTimeOffset.Now).ConfigureAwait(false);
            Logger.Log.Info($"{User.Identity.Name}  разблокировал пользователя {user.UserName}");
            return RedirectToAction("Details", new { id });
        }
    }
}