namespace E_Shop.Areas.Admin.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;

    using Model;

    using Service;

    using ViewModels.CategoryViewModels;

    using Web.Core.Extensions;

    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: Admin/Category
        [HttpGet]
        public ActionResult Index()
        {
            var categories = _categoryService.GetCategories();
            var model = categories.Select(Mapper.Map<Category, CategoryViewModel>);
            return View(model);
        }

        // GET: Admin/Category/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Category/Create
        [HttpPost]
        public ActionResult Create(CreateCategoryViewModel model)
        {
            var category = Mapper.Map<CreateCategoryViewModel, Category>(model);
            var errors = _categoryService.CanAddCategory(category);
            ModelState.AddModelErrors(errors);
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _categoryService.CreateCategory(category);
            Logger.Log.Info($"{User.Identity.Name} создал категорию №{category.CategoryId} с названием  {model.Name} ");
            return RedirectToAction("Index", "Attribute", new { categoryId = category.CategoryId });
        }

        // GET: Admin/Category/Edit/
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var category = _categoryService.GetCategory(id);
            if (category == null)
            {
                return RedirectToAction("NotFound", "Error", new { Area = string.Empty });
            }

            var model = Mapper.Map<Category, EditCategoryViewModel>(category);
            return View(model);
        }

        // POST: Admin/Category/Edit
        [HttpPost]
        public ActionResult Edit(EditCategoryViewModel model)
        {
            var newCategory = Mapper.Map<EditCategoryViewModel, Category>(model);
            var errors = _categoryService.CanAddCategory(newCategory);
            ModelState.AddModelErrors(errors);
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _categoryService.UpdateCategory(newCategory);
            Logger.Log.Info($"{User.Identity.Name} изменил категорию №{newCategory.CategoryId} {newCategory.Name} ");
            return RedirectToAction("Index");
        }
    }
}