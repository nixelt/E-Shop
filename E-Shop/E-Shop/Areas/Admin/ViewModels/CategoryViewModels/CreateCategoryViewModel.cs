namespace E_Shop.Areas.Admin.ViewModels.CategoryViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    using App_LocalResources;

    public class CreateCategoryViewModel : CategoryViewModel
    {
        [Display(Name = nameof(ViewModel.Image), ResourceType = typeof(ViewModel))]
        [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "Required")]
        public HttpPostedFileBase Image { get; set; }
    }
}