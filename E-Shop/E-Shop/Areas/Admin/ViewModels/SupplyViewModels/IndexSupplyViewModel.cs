namespace E_Shop.Areas.Admin.ViewModels.SupplyViewModels
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using E_Shop.ViewModels.PagerViewModel;

    public class IndexSupplyViewModel
    {
        public PagerViewModel<SupplyViewModel> Supplies { get; set; }

        public List<SelectListItem> Suppliers { get; set; }

        public string CurrentSupplier { get; set; }
    }
}