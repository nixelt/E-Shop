namespace E_Shop.Service
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using Data.Infrastructure;
    using Data.Repositories;
    using Model;

    public interface ICategoryService
    {
        List<Category> GetCategories();

        Category GetCategory(int id);

        IEnumerable<ValidationResult> CanAddCategory(Category newCategory);

        void CreateCategory(Category category);

        void UpdateCategory(Category category);
    }

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public List<Category> GetCategories()
        {
            var categories = _categoryRepository.GetAll().OrderBy(x => x.Name);
            return categories.ToList();
        }

        public Category GetCategory(int id)
        {
            var category = _categoryRepository.GetById(id);
            return category;
        }

        public IEnumerable<ValidationResult> CanAddCategory(Category newCategory)
        {
            Category category;
            if (newCategory.CategoryId == 0)
            {
                category = _categoryRepository.Get(x => x.Name == newCategory.Name);
            }
            else
            {
                category = _categoryRepository.Get(
                    x => x.Name == newCategory.Name && x.CategoryId != newCategory.CategoryId);
            }

            if (category != null)
            {
                yield return new ValidationResult("Категория с данным названием уже существует");
            }
        }

        public void CreateCategory(Category category)
        {
            _categoryRepository.Add(category);
            SaveCategory();
        }

        public void UpdateCategory(Category category)
        {
            _categoryRepository.Update(category);
            SaveCategory();
        }

        private void SaveCategory()
        {
            _unitOfWork.Commit();
        }
    }
}
