namespace E_Shop.Areas.Admin.ViewModels.CategoryViewModels
{
    using System.ComponentModel.DataAnnotations;

    using App_LocalResources;

    public class CategoryViewModel
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "Required")]
        [RegularExpression(@"^[А-Яа-яЁёЇїІіЄєҐґA-Z a-z\-']+$", ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "WrongInput")]
        [MaxLength(30, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MaxLength")]
        [Display(Name = nameof(ViewModel.Name), ResourceType = typeof(ViewModel))]
        public string Name { get; set; }
    }
}