namespace E_Shop.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;

    using Service.Enums;
    using Service.ProductFilters;
    using ViewModels.CategoryViewModels;
    using ViewModels.PagerViewModel;

    using Model;

    using Service;

    using ViewModels.ProductViewModels;

    public class CatalogController : Controller
    {
        private const int PageSize = 12;
        private readonly IAttributeService _attributeService;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public CatalogController(ICategoryService categoryService, IProductService productService, IAttributeService attributeService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _attributeService = attributeService;
        }

        // GET: Catalog
        public ActionResult Index()
        {
            var categories = _categoryService.GetCategories();
            var categoriesViewModels = categories.Select(Mapper.Map<Category, IndexCategoryViewModel>).ToList();
            return View(categoriesViewModels);
        }

        // GET: Catalog/Products
        public ActionResult Products(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("NotFound", "Error");
            }

            var category = _categoryService.GetCategory((int)id);
            if (category == null)
            {
                return RedirectToAction("NotFound", "Error");
            }

            var attributes = _attributeService.GetAttributesForFiltering(category.CategoryId);
            var filters = new List<IProductFilter> { new ProductCategoryFilter(category.CategoryId) };
            var sorter = new ProductSorter();
            var products = _productService.GetProductsForCustomer(sorter, filters);
            var productViewModels = PagerViewModelHelper<ProductViewModel>.ToPagerViewModel(products, 1, PageSize);
            var minPrice = products.Any() ? products.Min(x => x.Price) : 0;
            var maxPrice = products.Any() ? products.Max(x => x.Price) : 0;
            var productFilterViewModel = new ProductFilterViewModel
            {
                CategoryId = category.CategoryId,
                MinPrice = minPrice,
                MaxPrice = maxPrice
            };
            var model = new CategoryProductsViewModel
            {
                Attributes = attributes,
                Name = category.Name,
                Products = productViewModels,
                ProductFilterViewModel = productFilterViewModel
            };
            return View(model);
        }

        // GET: Catalog/ProductFilter
        public ActionResult GetProducts(CategoryProductsViewModel model)
        {
            var filterModel = model.ProductFilterViewModel;
            var filters = ProductFilterHelper.GetFilters(filterModel);
            var sorter = new ProductSorter((ProductOrderBy)filterModel.OrderBy);
            var products = _productService.GetProductsForCustomer(sorter, filters);
            var productViewModels = PagerViewModelHelper<ProductViewModel>.ToPagerViewModel(products, model.Page, PageSize);
            return PartialView("~/Views/Product/_ProductList.cshtml", productViewModels);
        }
    }
}