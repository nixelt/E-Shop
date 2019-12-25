namespace E_Shop.Areas.Admin.ViewModels.ProductViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    using System.Web.Mvc;

    using App_LocalResources;

    public class CreateProductViewModel : ProductViewModel
    {
        [AllowHtml]
        [Display(Name = nameof(ViewModel.Description), ResourceType = typeof(ViewModel))]
        [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "Required")]
        public string Description { get; set; }

        [Display(Name = nameof(ViewModel.Warranty), ResourceType = typeof(ViewModel))]
        [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "Required")]
        public string Warranty { get; set; }

        [Display(Name = nameof(ViewModel.Category), ResourceType = typeof(ViewModel))]
        [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "Required")]
        public int CategoryId { get; set; }
        [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "Required")]
        public List<HttpPostedFileBase> Images { get; set; }

        public List<SelectListItem> Categories { get; set; }
    }
}