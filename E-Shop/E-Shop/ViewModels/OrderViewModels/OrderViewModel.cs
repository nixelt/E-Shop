namespace E_Shop.ViewModels.OrderViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using App_LocalResources;

    public class OrderViewModel : ContactInfoViewModel
    {
        public int OrderId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "RequiredAddres")]
        [MaxLength(200, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MaxLength")]
        [Display(Name = nameof(ViewModel.Address), ResourceType = typeof(ViewModel))]
        public string Address { get; set; }

        [Display(Name = nameof(ViewModel.OrderDate), ResourceType = typeof(ViewModel))]
        public DateTime OrderDate { get; set; }

        [Display(Name = nameof(ViewModel.OrderStatus), ResourceType = typeof(ViewModel))]
        public string OrderStatus { get; set; }
    }
}