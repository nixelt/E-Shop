namespace E_Shop.Areas.Admin.Controllers
{
    using System.Web.Mvc;

    using AutoMapper;

    using E_Shop.ViewModels.PagerViewModel;

    using Model;

    using Service;

    using ViewModels.SupplierViewModels;

    using Web.Core.Extensions;

    public class SupplierController : Controller
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        // GET: Supplier
        public ActionResult Index()
        {
            var suppliers = _supplierService.GetSuppliers();
            var model = PagerViewModelHelper<SupplierViewModel>.ToPagerViewModel(suppliers);
            return View(model);
        }

        // GET: Supplier/GetSuppliers
        public ActionResult GetSuppliers(int page = 1, bool includeDeleted = false)
        {
            var suppliers = _supplierService.GetSuppliers(includeDeleted);
            var model = PagerViewModelHelper<SupplierViewModel>.ToPagerViewModel(suppliers, page);
            return PartialView("_Suppliers", model);
        }

        // GET: Supplier/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Supplier/Create
        [HttpPost]
        public ActionResult Create(SupplierViewModel model)
        {
            var supplier = Mapper.Map<SupplierViewModel, Supplier>(model);
            var errors = _supplierService.CanAddSupplier(supplier);
            ModelState.AddModelErrors(errors);
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _supplierService.CreateSupplier(supplier);
            Logger.Log.Info($"{User.Identity.Name} создал нового поставщика {model.Name}");
            return RedirectToAction("Index");
        }

        // GET: Supplier/Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var supplier = _supplierService.GetSupplier(id);
            if (supplier == null)
            {
                return RedirectToAction("NotFound", "Error", new { Area = string.Empty });
            }

            var model = Mapper.Map<Supplier, SupplierViewModel>(supplier);
            return View(model);
        }

        // POST: Supplier/Edit
        [HttpPost]
        public ActionResult Edit(SupplierViewModel model)
        {
            var supplier = Mapper.Map<SupplierViewModel, Supplier>(model);
            var errors = _supplierService.CanAddSupplier(supplier);
            ModelState.AddModelErrors(errors);
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _supplierService.UpdateSupplier(supplier);
            Logger.Log.Info($"{User.Identity.Name} изменил информацию о поставщике №{model.SupplierId} {model.Name} ");
            return RedirectToAction("Index");
        }

        // POST: Supplier/Delete
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var supplier = _supplierService.GetSupplier(id);
            if (supplier == null)
            {
                return RedirectToAction("NotFound", "Error", new { Area = string.Empty });
            }

            _supplierService.DeleteSupplier(supplier);
            Logger.Log.Info($"{User.Identity.Name} удалил поставщика №{id} {supplier.Name}");
            return RedirectToAction("Index");
        }

        // POST: Supplier/Restore
        [HttpPost]
        public ActionResult Restore(int id)
        {
            var supplier = _supplierService.GetSupplier(id);
            if (supplier == null)
            {
                return RedirectToAction("NotFound", "Error", new { Area = string.Empty });
            }

            _supplierService.RestoreSupplier(supplier);
            Logger.Log.Info($"{User.Identity.Name} восстановил поставщика №{id} {supplier.Name}");
            return RedirectToAction("Index");
        }
    }
}