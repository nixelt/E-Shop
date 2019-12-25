namespace E_Shop.ViewModels.ProductViewModels
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using Model;
    using Service.ProductFilters;

    public static class ProductFilterHelper
    {
        public static List<IProductFilter> GetFilters(ProductFilterViewModel model)
        {
            var filters = new List<IProductFilter> { new ProductCategoryFilter(model.CategoryId) };
            if (model.MaxPrice >= model.MinPrice)
            {
                filters.Add(new ProductPriceFilter(model.MinPrice, model.MaxPrice));
            }

            if (model.CheckedAttributes != null)
            {
                var checkedAttributes = model.CheckedAttributes.Select(Mapper.Map<AttributeValueViewModel, AttributeValue>);
                filters.Add(new ProductAttributeValueFilter(checkedAttributes));
            }

            return filters;
        }
    }
}