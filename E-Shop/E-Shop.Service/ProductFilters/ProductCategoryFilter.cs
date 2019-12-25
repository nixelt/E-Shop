namespace E_Shop.Service.ProductFilters
{
    using System.Collections.Generic;
    using System.Linq;

    using Model;

    public class ProductCategoryFilter : IProductFilter
    {
        private readonly int _categoryId;

        public ProductCategoryFilter(int categoryId)
        {
            _categoryId = categoryId;
        }

        public IEnumerable<Product> GetEntities(IEnumerable<Product> products)
        {
            products = products.Where(x => x.CategoryId == _categoryId);
            return products;
        }
    }
}
