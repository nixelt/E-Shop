namespace E_Shop.ViewModels.OrderViewModels
{
    using System.ComponentModel.DataAnnotations;

    using App_LocalResources;

    public class IndexCartItemViewModel : OrderDetailsViewModel
    {
        [Display(Name = nameof(ViewModel.QuantityInStock), ResourceType = typeof(ViewModel))]
        public int QuantityInStock { get; set; }
        [Display(Name = nameof(ViewModel.Image), ResourceType = typeof(ViewModel))]
        public byte[] Image { get; set; }
    }
}