namespace E_Shop.Areas.Admin.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;

    using E_Shop.ViewModels.PagerViewModel;
    using Web.Core.Extensions;

    using Model;

    using Service;

    using ViewModels.ProductViewModels;

    public class ProductController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public ProductController(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        // GET: Admin/Product
        public ActionResult Index()
        {
            var categories = _categoryService.GetCategories().Select(x => new SelectListItem { Text = x.Name, Value = x.CategoryId.ToString() });
            var sorter = new ProductSorter();
        
            var products = _productService.GetProductsForAdmin(sorter);
            var pagerViewModel = PagerViewModelHelper<ProductViewModel>.ToPagerViewModel(products);
            var model = new IndexProductViewModel { Products = pagerViewModel, Categories = categories.ToList() };
            return View(model);
        }

        // GET: Admin/Product/GetProducts
        public ActionResult GetProducts(IndexProductViewModel model)
        {
            var filterModel = model.ProductFilterViewModel;
            var filters = ProductFilterHelper.GetFilters(filterModel);
            var sorter = new ProductSorter();
            var products = _productService.GetProductsForAdmin(sorter, filters);
            var productViewModels = PagerViewModelHelper<ProductViewModel>.ToPagerViewModel(products, model.Page);
            return PartialView("_Products", productViewModels);
        }

        // GET: Admin/Product/Create
        [HttpGet]
        public ActionResult Create()
        {
            var categories = _categoryService.GetCategories()
                .Select(x => new SelectListItem { Text = x.Name, Value = x.CategoryId.ToString() });
            var model = new CreateProductViewModel
            {
                Categories = categories.ToList()
            };

            return View(model);
        }

        // POST: Admin/Product/Create
        [HttpPost]
        public ActionResult Create(CreateProductViewModel model)
        {
            var product = Mapper.Map<CreateProductViewModel, Product>(model);
            var errors = _productService.CanAddProduct(product);
            ModelState.AddModelErrors(errors);
            if (!ModelState.IsValid)
            {
                model.Categories = _categoryService.GetCategories().Select(x => new SelectListItem { Text = x.Name, Value = x.CategoryId.ToString() }).ToList();
                return View(model);
            }

            _productService.CreateProduct(product);
            Logger.Log.Info($"{User.Identity.Name} создал товар №{model.ProductId} {model.Name}");
            return RedirectToAction("Edit", "AttributeValue", new { productId = product.ProductId });
        }

        // GET: Admin/Product/Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product = _productService.GetProduct(id);
            if (product == null)
            {
                return RedirectToAction("NotFound", "Error", new { Area = string.Empty });
            }

            var model = Mapper.Map<Product, EditProductViewModel>(product);
            return View(model);
        }

        // POST: Admin/Product/Edit
        [HttpPost]
        public ActionResult Edit(EditProductViewModel model)
        {
            var product = Mapper.Map<EditProductViewModel, Product>(model);
            var errors = _productService.CanAddProduct(product).ToList();
            ModelState.AddModelErrors(errors);
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _productService.UpdateProduct(product);
            Logger.Log.Info($"{User.Identity.Name} изменил товар {product.Name} №{product.ProductId}");
            return RedirectToAction("Index");
        }

        // POST: Admin/Product/Delete
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var product = _productService.GetProduct(id);
            if (product == null)
            {
                return RedirectToAction("NotFound", "Error", new { Area = string.Empty });
            }

            _productService.DeleteProduct(product);
            Logger.Log.Info($"{User.Identity.Name} удалил товар №{id} {product.Name}");
            return RedirectToAction("Index", "Product");
        }

        // POST: Admin/Product/Restore
        [HttpPost]
        public ActionResult Restore(int id)
        {
            var product = _productService.GetProduct(id);
            if (product == null)
            {
                return RedirectToAction("NotFound", "Error", new { Area = string.Empty });
            }

            _productService.RestoreProduct(product);
            Logger.Log.Info($"{User.Identity.Name} восстановил товар №{id} {product.Name}");
            return RedirectToAction("Index", "Product");
        }
    }
}