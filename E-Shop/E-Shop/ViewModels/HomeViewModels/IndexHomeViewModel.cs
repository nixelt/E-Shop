namespace E_Shop.ViewModels.HomeViewModels
{
    using System.Collections.Generic;

    using CategoryViewModels;
    using PagerViewModel;
    using ProductViewModels;

    public class IndexHomeViewModel
    {
        public List<CategoryViewModel> Categories { get; set; }

        public PagerViewModel<ProductViewModel> Newest { get; set; }

        public PagerViewModel<ProductViewModel> MostPopular { get; set; }
    }
}