namespace E_Shop.Areas.Admin.ViewModels.SupplyViewModels
{
    using System.ComponentModel.DataAnnotations;

    using App_LocalResources;

    public class SupplyProductViewModel
    {
        public int ProductId { get; set; }

        [Display(Name = nameof(ViewModel.Name), ResourceType = typeof(ViewModel))]
        public string Name { get; set; }

        [Display(Name = nameof(ViewModel.Quantity), ResourceType = typeof(ViewModel))]
        public int Quantity { get; set; }

        [Display(Name = nameof(ViewModel.Price), ResourceType = typeof(ViewModel))]
        public int Price { get; set; }
    }
}