namespace E_Shop.Areas.Admin.ViewModels.CategoryViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    using App_LocalResources;

    public class EditCategoryViewModel : CategoryViewModel
    {
        [Required]
        public byte[] Image { get; set; }

        [Display(Name = nameof(ViewModel.Image), ResourceType = typeof(ViewModel))]
        public HttpPostedFileBase NewImage { get; set; }
    }
}