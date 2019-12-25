namespace E_Shop.ViewModels.OrderViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using App_LocalResources;

    public class CreateOrderViewModel : OrderViewModel
    {

        [MaxLength(3000, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MaxLength")]
        [Display(Name = nameof(ViewModel.Comment), ResourceType = typeof(ViewModel))]
        public string Comment { get; set; }

        public List<IndexCartItemViewModel> CartItems { get; set; }
    }
}