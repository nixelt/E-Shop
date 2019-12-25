namespace E_Shop.Areas.Admin.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;

    using E_Shop.ViewModels.PagerViewModel;

    using Model;

    using Service;
    using ViewModels.SupplyViewModels;

    public class SupplyController : Controller
    {
        private readonly ISupplyService _supplyService;

        private readonly ISupplierService _supplierService;

        private readonly IProductService _productService;

        public SupplyController(ISupplyService supplyService, IProductService productService, ISupplierService supplierService)
        {
            _supplyService = supplyService;
            _productService = productService;
            _supplierService = supplierService;
        }

        // GET: Admin/Supply
        public ActionResult Index(string supplier = null)
        {
            var suppliers = _supplierService.GetSuppliers();
            var supplierList = new List<SelectListItem>(
                suppliers.Select(x => new SelectListItem { Text = x.Name, Value = x.SupplierId.ToString() }));
            var supplierId = _supplierService.GetSupplier(supplier)?.SupplierId;
            var supplies = _supplyService.GetSupplies(supplierId);
            var supplyList = PagerViewModelHelper<SupplyViewModel>.ToPagerViewModel(supplies);
            var model = new IndexSupplyViewModel
            {
                CurrentSupplier = supplier,
                Suppliers = supplierList,
                Supplies = supplyList
            };
            return View(model);
        }

        // GET: Admin/Supply/Details
        public ActionResult Details(int id)
        {
            var supply = _supplyService.GetSupply(id);
            if (supply == null)
            {
                return RedirectToAction("NotFound", "Error", new { Area = string.Empty });
            }

            var model = Mapper.Map<Supply, DetailsSupplyViewModel>(supply);
            return View(model);
        }

        // GET: Admin/Supply/GetSupplies
        public ActionResult GetSupplies(int? supplierId, int page = 1)
        {
            var supplies = _supplyService.GetSupplies(supplierId);
            var model = PagerViewModelHelper<SupplyViewModel>.ToPagerViewModel(supplies, page);
            return PartialView("_Supplies", model);
        }

        // GET: Admin/Supply/Create
        [HttpGet]
        public ActionResult Create()
        {
            var suppliers = _supplierService.GetSuppliers().Select(x => new SelectListItem { Text = x.Name, Value = x.SupplierId.ToString() });
            var sorter = new ProductSorter();
            var products = _productService.GetProductsForAdmin(sorter).Select(x => new SelectListItem { Text = x.Name, Value = x.ProductId.ToString() });
            var model = new CreateSupplyViewModel
            {
                Suppliers = suppliers.ToList(),
                Products = products.ToList()
            };
            return View(model);
        }

        // POST: Admin/Supply/Create
        [HttpPost]
        public ActionResult Create(CreateSupplyViewModel model)
        {
            model.SupplyProducts = model.SupplyProducts.Where(x => x.Quantity != 0).ToList();
            if (!model.SupplyProducts.Any())
            {
                return RedirectToAction("Index");
            }

            var supply = Mapper.Map<CreateSupplyViewModel, Supply>(model);
            supply.SupplyDate = DateTime.Now;
            _supplyService.CreateSupply(supply);
            Logger.Log.Info($"{User.Identity.Name} создал новую поставку №{model.SupplyId}");
            return RedirectToAction("Details", new { id = supply.SupplyId });
        }
    }
}