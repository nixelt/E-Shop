namespace E_Shop.ViewModels.SettingsViewModels
{
    using System.ComponentModel.DataAnnotations;

    using App_LocalResources;

    public class ChangePasswordViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "Required")]
        [StringLength(100, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "StringLength", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = nameof(ViewModel.Password), ResourceType = typeof(ViewModel))]
        public string Password { get; set; }

        [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "Required")]
        [StringLength(100, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "StringLength", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = nameof(ViewModel.NewPassword), ResourceType = typeof(ViewModel))]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = nameof(ViewModel.ConfirmPassword), ResourceType = typeof(ViewModel))]
        [Compare("NewPassword", ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "DifferentPasswords")]
        public string ConfirmPassword { get; set; }
    }
}