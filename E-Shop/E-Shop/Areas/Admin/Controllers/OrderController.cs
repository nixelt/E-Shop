namespace E_Shop.Areas.Admin.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;

    using E_Shop.ViewModels.PagerViewModel;

    using Microsoft.AspNet.Identity;

    using Model;

    using Service;

    using ViewModels.OrderViewModels;

    using WebGrease.Css.Extensions;

    using DetailsOrderViewModel = ViewModels.OrderViewModels.DetailsOrderViewModel;

    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        private readonly IOrderStatusService _orderStatusService;

        public OrderController(IOrderService orderService, IOrderStatusService orderStatusService)
        {
            _orderService = orderService;
            _orderStatusService = orderStatusService;
        }

        // GET: Admin/Order
        public ActionResult Index()
        {
            var orderStatuses = _orderStatusService.GetOrderStatuses();
            var statuses = new List<SelectListItem>(orderStatuses.Select(x => new SelectListItem { Text = x.Name, Value = x.OrderStatusId.ToString() }));
            var orders = _orderService.GetOrders();
            var pagerViewModel = PagerViewModelHelper<OrderViewModel>.ToPagerViewModel(orders);
            var model = new IndexOrderViewModel { OrderStatuses = statuses, OrderList = pagerViewModel };
            return View(model);
        }

        // GET: Admin/Order/GetOrders
        public ActionResult GetOrders(IndexOrderViewModel model)
        {
            var managerId = model.OnlyMyOrders != null ? User?.Identity.GetUserId() : null;
            var orders = _orderService.GetOrders(model.OrderStatusId, managerId: managerId);
            var orderList = PagerViewModelHelper<OrderViewModel>.ToPagerViewModel(orders, model.Page);
            return PartialView("_Orders", orderList);
        }

        // GET: Admin/Order/Details
        public ActionResult Details(int id, string message)
        {
            ViewData["Message"] = message;
            var order = _orderService.GetOrder(id);
            if (order == null)
            {
                return RedirectToAction("NotFound", "Error", new { Area = string.Empty });
            }

            var model = Mapper.Map<Order, DetailsOrderViewModel>(order);
            return View(model);
        }

        // POST: Admin/Order/AcceptOrder
        [HttpPost]
        public ActionResult AcceptOrder(int id)
        {
            var order = _orderService.GetOrder(id);
            if (order == null)
            {
                return RedirectToAction("NotFound", "Error", new { Area = string.Empty });
            }

            var errors = _orderService.CanAcceptOrder(order);
            if (errors.Count() != 0)
            {
                var msg = string.Empty;
                errors.ForEach(x => msg += x.ErrorMessage);
                return RedirectToAction("Details", new { id, message = msg });
            }

            var userId = User.Identity.GetUserId();
            _orderService.AcceptOrder(order, userId);
            Logger.Log.Info($"{User.Identity.Name} принял заказ №{order.OrderId}");
            return RedirectToAction("Details", new { id });
        }

        // POST: Admin/Order/OrderPaid
        [HttpPost]
        public ActionResult OrderPaid(int id)
        {
            var order = _orderService.GetOrder(id);
            if (order == null)
            {
                return RedirectToAction("NotFound", "Error", new { Area = string.Empty });
            }

            if (order.ManagerId != User.Identity.GetUserId() && !User.IsInRole("Admin"))
            {
                return RedirectToAction("Details", new { id, message = "Вы не принимали этот заказ!" });
            }

            _orderService.OrderPaid(order);
            Logger.Log.Info($"{User.Identity.Name} перевел заказ №{order.OrderId} в статус \"Оплачен\"");
            return RedirectToAction("Details", new { id });
        }

        // POST: Admin/Order/OrderCompleted
        [HttpPost]
        public ActionResult OrderCompleted(int id)
        {
            var order = _orderService.GetOrder(id);
            if (order == null)
            {
                return RedirectToAction("NotFound", "Error", new { Area = string.Empty });
            }

            if (order.ManagerId != User.Identity.GetUserId() && !User.IsInRole("Admin"))
            {
                return RedirectToAction("Details", new { id, message = "Вы не принимали этот заказ!" });
            }

            _orderService.OrderCompleted(order);
            Logger.Log.Info($"{User.Identity.Name} перевел заказ №{order.OrderId} в статус \"Выполнен\"");
            return RedirectToAction("Details", new { id });
        }

        // POST: Admin/Order/Cancel
        [HttpPost]
        public ActionResult Cancel(int id)
        {
            var order = _orderService.GetOrder(id);
            if (order == null)
            {
                return RedirectToAction("NotFound", "Error", new { Area = string.Empty });
            }

            if (order.ManagerId != User.Identity.GetUserId() && !User.IsInRole("Admin"))
            {
                return RedirectToAction("Details", new { id, message = "Вы не принимали этот заказ!" });
            }

            _orderService.CancelOrder(order);
            Logger.Log.Info($"{User.Identity.Name} перевел заказ №{order.OrderId} в статус \"Отменен\"");
            return RedirectToAction("Details", new { id });
        }
    }
}