namespace E_Shop.Areas.Admin.ViewModels.ProductViewModels
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using E_Shop.ViewModels.PagerViewModel;

    public class IndexProductViewModel
    {
        public ProductFilterViewModel ProductFilterViewModel { get; set; }

        public PagerViewModel<ProductViewModel> Products { get; set; }
        
        public List<SelectListItem> Categories { get; set; }

        public int Page { get; set; }
    }
}