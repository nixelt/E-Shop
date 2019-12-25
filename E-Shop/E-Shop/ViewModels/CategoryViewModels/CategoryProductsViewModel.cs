namespace E_Shop.ViewModels.CategoryViewModels
{
    using System.Collections.Generic;

    using Model;
    using PagerViewModel;
    using ProductViewModels;

    public class CategoryProductsViewModel : CategoryViewModel
    {
        public ProductFilterViewModel ProductFilterViewModel { get; set; }

        public List<Attribute> Attributes { get; set; }

        public PagerViewModel<ProductViewModel> Products { get; set; }

        public int Page { get; set; }
    }
}