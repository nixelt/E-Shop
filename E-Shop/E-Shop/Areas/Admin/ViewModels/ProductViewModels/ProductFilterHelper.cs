namespace E_Shop.Areas.Admin.ViewModels.ProductViewModels
{
    using System.Collections.Generic;

    using Service.ProductFilters;

    public class ProductFilterHelper
    {
        public static List<IProductFilter> GetFilters(ProductFilterViewModel model)
        {
            var filters = new List<IProductFilter>();
            if (model.CategoryId != null)
            {
                filters.Add(new ProductCategoryFilter((int)model.CategoryId));
            }

            if (!string.IsNullOrWhiteSpace(model.Search))
            {
                filters.Add(new ProductNameFilter(model.Search));
            }

            filters.Add(new ProductDeletedFilter(model.OnlyDeleted));

            return filters;
        }
    }
}