namespace E_Shop.ViewModels.AccountViewModels
{
    using System.ComponentModel.DataAnnotations;

    using App_LocalResources;

    public class RegisterViewModel : ContactInfoViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "Required")]
        [StringLength(100, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "StringLength", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = nameof(ViewModel.Password), ResourceType = typeof(ViewModel))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = nameof(ViewModel.ConfirmPassword), ResourceType = typeof(ViewModel))]
        [Compare("Password", ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "DifferentPasswords")]
        public string ConfirmPassword { get; set; }
    }
}