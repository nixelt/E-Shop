namespace E_Shop.Areas.Admin.ViewModels.SupplierViewModels
{
    using System.ComponentModel.DataAnnotations;

    using App_LocalResources;

    public class SupplierViewModel
    {
        public int SupplierId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "Required")]
        [MaxLength(50, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MaxLength")]
        [Display(Name = nameof(ViewModel.Supplier), ResourceType = typeof(ViewModel))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "Required")]
        [RegularExpression(@"^(\+)?(38)?0([- _():=+]?\d){9}$", ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "WrongInput")]
        [MaxLength(13, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MaxLength")]
        [Display(Name = nameof(ViewModel.Phone), ResourceType = typeof(ViewModel))]
        public string Phone { get; set; }

        public bool IsDeleted { get; set; }
    }
}