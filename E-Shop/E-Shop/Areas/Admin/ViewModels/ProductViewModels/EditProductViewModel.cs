namespace E_Shop.Areas.Admin.ViewModels.ProductViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using App_LocalResources;

    public class EditProductViewModel : ProductViewModel
    {
        [AllowHtml]
        [Display(Name = nameof(ViewModel.Description), ResourceType = typeof(ViewModel))]
        public string Description { get; set; }
        [Display(Name = nameof(ViewModel.Warranty), ResourceType = typeof(ViewModel))]
        [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "Required")]
        public string Warranty { get; set; }

        [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "Required")]
        public int CategoryId { get; set; }
    }
}