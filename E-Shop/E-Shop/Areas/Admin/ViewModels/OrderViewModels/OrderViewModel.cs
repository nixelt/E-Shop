namespace E_Shop.Areas.Admin.ViewModels.OrderViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using App_LocalResources;
    using Model;

    public class OrderViewModel
    {
        public int OrderId { get; set; }

        public string CustomerId { get; set; }

        [Display(Name = nameof(ViewModel.Customer), ResourceType = typeof(ViewModel))]
        public string FullName { get; set; }

        [Display(Name = nameof(ViewModel.Phone), ResourceType = typeof(ViewModel))]
        public string Phone { get; set; }

        [Display(Name = nameof(ViewModel.OrderStatus), ResourceType = typeof(ViewModel))]
        public OrderStatus OrderStatus { get; set; }

        [Display(Name = nameof(ViewModel.OrderDate), ResourceType = typeof(ViewModel))]
        public DateTime OrderDate { get; set; }
    }
}