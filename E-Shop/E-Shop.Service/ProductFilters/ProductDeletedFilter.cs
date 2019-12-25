namespace E_Shop.Service.ProductFilters
{
    using System.Collections.Generic;
    using System.Linq;

    using Model;

    public class ProductDeletedFilter : IProductFilter
    {
        private readonly bool _deleted;

        public ProductDeletedFilter(bool deleted)
        {
            _deleted = deleted;
        }

        public IEnumerable<Product> GetEntities(IEnumerable<Product> products)
        {
            products = products.Where(x => x.IsDeleted == _deleted);
            return products;
        }
    }
}
