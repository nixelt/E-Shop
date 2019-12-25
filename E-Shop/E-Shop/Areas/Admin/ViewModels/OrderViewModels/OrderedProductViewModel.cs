namespace E_Shop.Areas.Admin.ViewModels.OrderViewModels
{
    using System.ComponentModel.DataAnnotations;

    using App_LocalResources;

    public class OrderedProductViewModel
    {
        public int ProductId { get; set; }
        [Display(Name = nameof(ViewModel.Name), ResourceType = typeof(ViewModel))]
        public string Name { get; set; }
        [Display(Name = nameof(ViewModel.Price), ResourceType = typeof(ViewModel))]
        public int Price { get; set; }
        [Display(Name = nameof(ViewModel.QuantityInCart), ResourceType = typeof(ViewModel))]
        public int QuantityInCart { get; set; }
        [Display(Name = nameof(ViewModel.QuantityInStock), ResourceType = typeof(ViewModel))]
        public int QuantityInStock { get; set; }
    }
}