namespace E_Shop.ViewModels.AccountViewModels
{
    using System.ComponentModel.DataAnnotations;

    using App_LocalResources;

    public class LoginViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "Required")]
        [Display(Name = nameof(ViewModel.Email), ResourceType = typeof(ViewModel))]
        [EmailAddress(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "WrongInput")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "Required")]
        [DataType(DataType.Password)]
        [Display(Name = nameof(ViewModel.Password), ResourceType = typeof(ViewModel))]
        public string Password { get; set; }
    }
}