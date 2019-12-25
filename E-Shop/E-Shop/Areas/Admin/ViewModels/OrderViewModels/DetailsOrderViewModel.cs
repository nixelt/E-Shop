namespace E_Shop.Areas.Admin.ViewModels.OrderViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using App_LocalResources;

    public class DetailsOrderViewModel : OrderViewModel
    {
        [Display(Name = nameof(ViewModel.Manager), ResourceType = typeof(ViewModel))]
        public string Manager { get; set; }
        [Display(Name = nameof(ViewModel.Address), ResourceType = typeof(ViewModel))]
        public string Address { get; set; }
        [Display(Name = nameof(ViewModel.Email), ResourceType = typeof(ViewModel))]
        public string Email { get; set; }
        [Display(Name = nameof(ViewModel.AcceptedDate), ResourceType = typeof(ViewModel))]
        public DateTime AcceptedDate { get; set; }
        [Display(Name = nameof(ViewModel.Comment), ResourceType = typeof(ViewModel))]
        public string Comment { get; set; }
        public List<OrderedProductViewModel> OrderedProducts { get; set; }
    }
}