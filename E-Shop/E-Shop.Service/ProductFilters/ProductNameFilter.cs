namespace E_Shop.Service.ProductFilters
{
    using System.Collections.Generic;
    using System.Linq;

    using Model;

    public class ProductNameFilter : IProductFilter
    {
        private readonly string _term;

        public ProductNameFilter(string term)
        {
            _term = term;
        }

        public IEnumerable<Product> GetEntities(IEnumerable<Product> products)
        {
            products = products.Where(x => x.Name.ToLower().Contains(_term.ToLower()));
            return products;
        }
    }
}
