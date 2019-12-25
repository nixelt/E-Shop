namespace E_Shop.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;

    using ViewModels.CategoryViewModels;
    using ViewModels.HomeViewModels;
    using ViewModels.PagerViewModel;

    using Model;
    using Service;

    using ViewModels.ProductViewModels;

    public class HomeController : Controller
    {
        private const int PageSize = 12;
        private readonly ICategoryService _categoryService;

        private readonly IProductService _productService;

        public HomeController(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        // GET: Home
        public ActionResult Index()
        {
            var categories = _categoryService.GetCategories().Select(Mapper.Map<Category, CategoryViewModel>);
            var sorter = new ProductSorter();
            var newest = _productService.GetProductsForCustomer(sorter).Take(PageSize).ToList();
            var mostPopular = _productService.GetProductsForCustomer(sorter).Take(PageSize).ToList();
            var newestPager = PagerViewModelHelper<ProductViewModel>.ToPagerViewModel(newest, 1, PageSize);
            var mostPopularPager = PagerViewModelHelper<ProductViewModel>.ToPagerViewModel(mostPopular, 1, PageSize);
            var model = new IndexHomeViewModel { Categories = categories.ToList(), Newest = newestPager, MostPopular = mostPopularPager };
            return View(model);
        }

        // GET: Home/Warranty
        public ActionResult Warranty()
        {
            return View();
        }

        // GET: Home/Delivery
        public ActionResult Delivery()
        {
            return View();
        }

        // GET: Home/Contact
        public ActionResult Contact()
        {
            return View();
        }

        // GET: Home/About
        public ActionResult About()
        {
            return View();
        }
    }
}