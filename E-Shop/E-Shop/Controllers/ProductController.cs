namespace E_Shop.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;

    using Service.ProductFilters;
    using ViewModels.PagerViewModel;

    using Microsoft.AspNet.Identity;

    using Model;
    using Service;

    using ViewModels.ProductViewModels;

    public class ProductController : Controller
    {
        private const int PageSize = 12;
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: Product
        public ActionResult Index(int id)
        {
            var product = _productService.GetProduct(id);
            if (product == null)
            {
                return RedirectToAction("NotFound", "Error");
            }

            if (product.IsDeleted && !User.IsInRole("Manager"))
            {
                return RedirectToAction("NotFound", "Error");
            }

            var model = Mapper.Map<Product, DetailsProductViewModel>(product);
            model.CanAddReview = product.Reviews.All(x => x.UserId != User.Identity.GetUserId());
            return View(model);
        }

        // GET: Product/Search
        public ActionResult Search(string input)
        {
            var filters = new List<IProductFilter> { new ProductNameFilter(input) };
            var sorter = new ProductSorter();
            var products = _productService.GetProductsForCustomer(sorter, filters);
            var model = PagerViewModelHelper<ProductViewModel>.ToPagerViewModel(products, 1, PageSize);
            return View(model);
        }
    }
}