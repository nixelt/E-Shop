namespace E_Shop.Areas.Admin.ViewModels.ProductViewModels
{
    using System.ComponentModel.DataAnnotations;

    using App_LocalResources;

    public class ProductViewModel
    {
        public int ProductId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "Required")]
        [MaxLength(200, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MaxLength")]
        [Display(Name = nameof(ViewModel.Name), ResourceType = typeof(ViewModel))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "Required")]
        [Range(0, int.MaxValue, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "Range")]
        [Display(Name = nameof(ViewModel.Price), ResourceType = typeof(ViewModel))]
        public int Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "Range")]
        [Display(Name = nameof(ViewModel.OldPrice), ResourceType = typeof(ViewModel))]
        public int OldPrice { get; set; }

        [Range(0, int.MaxValue, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "Range")]
        [Display(Name = nameof(ViewModel.Quantity), ResourceType = typeof(ViewModel))]
        public int Quantity { get; set; }

        public bool IsDeleted { get; set; }
    }
}