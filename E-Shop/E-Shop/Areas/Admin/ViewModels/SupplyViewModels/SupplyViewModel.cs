using System;

namespace E_Shop.Areas.Admin.ViewModels.SupplyViewModels
{
    using System.ComponentModel.DataAnnotations;

    using App_LocalResources;
    using SupplierViewModels;

    public class SupplyViewModel
    {
        public int SupplyId { get; set; }

        public SupplierViewModel Supplier { get; set; }

        [Display(Name = nameof(ViewModel.SupplyDate), ResourceType = typeof(ViewModel))]
        public DateTime SupplyDate { get; set; }
    }
}