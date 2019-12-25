namespace E_Shop.Areas.Admin.ViewModels.CategoryViewModels
{
    using System.Collections.Generic;

    using AttributeViewModels;

    public class DetailsCategoryViewModel : CategoryViewModel
    {
        public List<AttributeViewModel> Attributes { get; set; }
    }
}