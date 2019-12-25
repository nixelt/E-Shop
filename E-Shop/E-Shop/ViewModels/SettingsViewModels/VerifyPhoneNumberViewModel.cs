namespace E_Shop.ViewModels.SettingsViewModels
{
    using System.ComponentModel.DataAnnotations;

    using App_LocalResources;

    public class VerifyPhoneNumberViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "Required")]
        [Display(Name = nameof(ViewModel.Code), ResourceType = typeof(ViewModel))]
        public string Code { get; set; }

        [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "Required")]
        [MaxLength(13, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MaxLength")]
        [RegularExpression(@"^(\+)?(38)?0([- _():=+]?\d){9}$", ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "WrongInput")]
        [Display(Name = nameof(ViewModel.Phone), ResourceType = typeof(ViewModel))]
        public string PhoneNumber { get; set; }
    }
}