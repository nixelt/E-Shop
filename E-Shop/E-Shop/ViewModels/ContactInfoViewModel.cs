namespace E_Shop.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using App_LocalResources;

    public class ContactInfoViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "Required")]
        [RegularExpression(@"^[А-Яа-яЁёЇїІіЄєҐґA-Za-z\-']+$", ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "WrongInput")]
        [MaxLength(50, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MaxLength")]
        [Display(Name = nameof(ViewModel.FirstName), ResourceType = typeof(ViewModel))]
        public string FirstName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "Required")]
        [RegularExpression(@"^[А-Яа-яЁёЇїІіЄєҐґA-Za-z\-']+$", ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "WrongInput")]
        [MaxLength(50, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MaxLength")]
        [Display(Name = nameof(ViewModel.MiddleName), ResourceType = typeof(ViewModel))]
        public string MiddleName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "Required")]
        [RegularExpression(@"^[А-Яа-яЁёЇїІіЄєҐґA-Za-z\-']+$", ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "WrongInput")]
        [MaxLength(50, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MaxLength")]
        [Display(Name = nameof(ViewModel.LastName), ResourceType = typeof(ViewModel))]
        public string LastName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "Required")]
        [MaxLength(13, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MaxLength")]
        [RegularExpression(@"^(\+)?(38)?0([- _():=+]?\d){9}$", ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "WrongInput")]
        [Display(Name = nameof(ViewModel.Phone), ResourceType = typeof(ViewModel))]
        public string Phone { get; set; }

        [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "Required")]
        [MaxLength(100, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MaxLength")]
        [EmailAddress(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "WrongInput")]
        [Display(Name = nameof(ViewModel.Email), ResourceType = typeof(ViewModel))]
        public string Email { get; set; }
    }
}