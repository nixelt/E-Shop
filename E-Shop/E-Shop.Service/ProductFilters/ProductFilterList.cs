namespace E_Shop.Service.ProductFilters
{
    using System.Collections.Generic;

    public static class ProductFilterList
    {
        public static List<IProductFilter> BaseFiltersForAdmin()
        {
            var list = new List<IProductFilter> { new ProductDeletedFilter(false) };
            return list;
        }

        public static List<IProductFilter> RequiredFiltersForCustomer()
        {
            var list = new List<IProductFilter> { new ProductDeletedFilter(false) };
            return list;
        }
    }
}
