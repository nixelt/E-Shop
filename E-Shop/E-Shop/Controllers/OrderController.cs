namespace E_Shop.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    using AutoMapper;

    using Data.Identity;

    using ViewModels.LiqPay;
    using ViewModels.PagerViewModel;

    using Microsoft.AspNet.Identity;

    using Model;

    using Newtonsoft.Json;

    using Service;

    using ViewModels.OrderViewModels;

    [Filters.Authorize]
    public class OrderController : Controller
    {
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly ApplicationUserManager _userManager;

        public OrderController(IOrderService orderService, IProductService productService, ApplicationUserManager userManager)
        {
            _orderService = orderService;

            _productService = productService;
            _userManager = userManager;
        }

        // GET: Order
        public ActionResult Index()
        {
            var customerId = User.Identity.GetUserId();
            var orders = _orderService.GetOrders(customerId: customerId);
            var model = PagerViewModelHelper<OrderViewModel>.ToPagerViewModel(orders);
            return View(model);
        }

        // GET: Order/Details
        public ActionResult Details(int id)
        {
            var order = _orderService.GetOrder((int)id);
            if (order == null)
            {
                return RedirectToAction("NotFound", "Error");
            }

            if (order.CustomerId != User.Identity.GetUserId())
            {
                return RedirectToAction("Forbidden", "Error");
            }

            var model = Mapper.Map<Order, DetailsOrderViewModel>(order);

            if (order.OrderStatusId == 2)
            {
                var urlReferrer = ControllerContext.RequestContext.HttpContext.Request.UrlReferrer.Authority;
                var urlAction = new UrlHelper(ControllerContext.RequestContext).Action("PayResult");
                var returnUrl = urlReferrer + urlAction;
                var liqPayModel = LiqPayHelper.GetLiqPayModel(order, returnUrl);
                model.LiqPayCheckoutFormModel = liqPayModel;
            }

            return View(model);
        }

        // GET: Order/Create
        [HttpGet]
        public async Task<ActionResult> Create(List<IndexCartItemViewModel> cartItems)
        {
            cartItems = GetDetails(cartItems);
            var userId = User.Identity.GetUserId();
            var user = await _userManager.FindByIdAsync(userId).ConfigureAwait(false);
            var model = Mapper.Map<User, CreateOrderViewModel>(user);
            model.CartItems = cartItems;
            return View(model);
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(CreateOrderViewModel model)
        {
            if (model.CartItems.Count != 0)
            {
                model.CartItems = GetDetails(model.CartItems);
                for (var i = 0; i < model.CartItems.Count; i++)
                {
                    var cartItem = model.CartItems[i];
                    if (cartItem.QuantityInCart > cartItem.QuantityInStock)
                    {
                        const string CartItems = nameof(model.CartItems);
                        const string QuantityInCart = nameof(cartItem.QuantityInCart);
                        ModelState.AddModelError(
                            $"{CartItems}[{i}].{QuantityInCart}",
                            $@"{cartItem.Name} максимальный заказ - {cartItem.QuantityInStock}");
                    }
                }
            }

            if (model.CartItems.Count == 0 || model.CartItems.All(x => x.QuantityInCart == 0))
            {
                ModelState.AddModelError(string.Empty, @"Корзина пуста!");
            }

            if (!ModelState.IsValid)
            {
                return Json(new { success = false, errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList() }, JsonRequestBehavior.AllowGet);
            }

            var order = Mapper.Map<CreateOrderViewModel, Order>(model);
            order.OrderDate = DateTime.Now;
            order.AcceptedDate = DateTime.Now;
            order.OrderStatusId = 1;
            order.CustomerId = User.Identity.GetUserId();
            var orderedProducts = model.CartItems.Where(x => x.QuantityInCart != 0)
                .Select(x => new { product = _productService.GetProduct(x.ProductId), x.QuantityInCart });
            var orderDetails = orderedProducts.Select(x => new OrderDetails
            {
                ProductId = x.product.ProductId,
                Price = x.product.Price,
                Quantity = x.QuantityInCart
            }).ToList();
            order.OrderDetails = orderDetails;
            _orderService.CreateOrder(order);
            Logger.Log.Info($"На сайте появился заказ №{order.OrderId}");
            return Json(new { success = true, returnUrl = Url.Action("Details", new { id = order.OrderId }) });
        }

        [HttpPost]
        public ActionResult PayResult()
        {
            var requestDictionary = Request.Form.AllKeys.ToDictionary(key => key, key => Request.Form[key]);

            var requestData = Convert.FromBase64String(requestDictionary["data"]);
            var decodedString = Encoding.UTF8.GetString(requestData);
            var requestDataDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(decodedString);

            var mySignature = LiqPayHelper.GetLiqPaySignature(requestDictionary["data"]);

            if (mySignature != requestDictionary["signature"])
            {
                return View("Error");
            }

            if (requestDataDictionary["status"] != "sandbox" && requestDataDictionary["status"] != "success")
            {
                return View("PayResultFailure");
            }

            var orderId = Convert.ToInt32(requestDataDictionary["order_id"]);
            var order = _orderService.GetOrder(orderId);
            if (order == null)
            {
                Logger.Log.Warn($"Заказ №{orderId} оплачен, но не был найден!");
                return View("Error");
            }

            _orderService.OrderPaid(order);
            Logger.Log.Info($"{User.Identity.Name} оплатил заказ №{orderId} через LiqPay");
            return View("PayResultSuccess");
        }

        // Get details about products in cart
        private List<IndexCartItemViewModel> GetDetails(IEnumerable<IndexCartItemViewModel> cartItems)
        {
            var newCartItems = new List<IndexCartItemViewModel>();
            foreach (var item in cartItems)
            {
                var product = _productService.GetProduct(Convert.ToInt32(item.ProductId));
                var newCartItem = Mapper.Map<Product, IndexCartItemViewModel>(product);
                newCartItem.QuantityInCart = item.QuantityInCart;
                newCartItems.Add(newCartItem);
            }

            return newCartItems;
        }
    }
}