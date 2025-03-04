﻿namespace E_Shop.Areas.Admin.Controllers
{
    using System.ComponentModel.DataAnnotations;
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

    using Web.Core.Extensions;

    [Authorize(Roles = "Admin")]
    public class ManagerController : Controller
    {
        private const int PageSize = 10;
        private readonly ApplicationUserManager _userManager;
        private readonly ApplicationRoleManager _roleManager;
        private readonly IOrderService _orderService;

        public ManagerController(ApplicationUserManager userManager, IOrderService orderService, ApplicationRoleManager roleManager)
        {
            _userManager = userManager;
            _orderService = orderService;
            _roleManager = roleManager;
        }

        // GET: Admin/Manager
        public async Task<ActionResult> Index(string msg = null)
        {
            ViewData["Message"] = msg;
            var role = await _roleManager.FindByNameAsync("Manager").ConfigureAwait(false);
            var managersId = role.Users.Take(PageSize).Select(x => x.UserId);
            var managers = managersId.Select(x => _userManager.FindById(x)).ToList();
            var model = PagerViewModelHelper<UserViewModel>.ToPagerViewModel(managers);
            return View("Index", model);
        }

        // GET: Admin/Manager/Details
        [HttpGet]
        public async Task<ActionResult> Details(string id, string msg = null)
        {
            ViewData["Message"] = msg;
            var user = await _userManager.FindByIdAsync(id).ConfigureAwait(false);
            if (user == null)
            {
                return RedirectToAction("NotFound", "Error", new { Area = string.Empty });
            }

            user.Orders = _orderService.GetOrders(managerId: id);
            var model = Mapper.Map<User, DetailsUserViewModel>(user);
            return View(model);
        }

        // POST: Admin/Manager/Fire
        [HttpPost]
        public async Task<ActionResult> Fire(string id)
        {
            var user = await _userManager.FindByIdAsync(id).ConfigureAwait(false);
            if (user == null)
            {
                return RedirectToAction("NotFound", "Error", new { Area = string.Empty });
            }

            if (await _userManager.IsInRoleAsync(id, "Admin").ConfigureAwait(false))
            {
                return RedirectToAction("Details", new { id, msg = "Вы не можете уволить адмнистратора!" });
            }

            await _userManager.RemoveFromRoleAsync(id, "Manager").ConfigureAwait(false);
            Logger.Log.Info($"{User.Identity.Name} уволил пользователя {user.UserName}");
            return RedirectToAction("Index");
        }

        // GET: Admin/Manager/Create
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        // POST: Admin/Manager/Create
        [HttpPost]
        public async Task<ActionResult> Add(string email)
        {
            var user = await _userManager.FindByEmailAsync(email).ConfigureAwait(false);
            if (user == null)
            {
                ModelState.AddModelError(nameof(email), $@"{email} не найден");
                return View();
            }

            var result = await _userManager.AddToRoleAsync(user.Id, "Manager").ConfigureAwait(false);
            if (result.Succeeded)
            {
                Logger.Log.Info($"{User.Identity.Name} добавил нового менеджера - {user.UserName}");
                return RedirectToAction("Details", new { id = user.Id });
            }

            ModelState.AddModelErrors(result.Errors.Select(x => new ValidationResult(x)));
            return View();
        }
    }
}