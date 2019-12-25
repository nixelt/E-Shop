namespace E_Shop.ViewModels.AccountViewModels
{
    using System.ComponentModel.DataAnnotations;

    using App_LocalResources;

    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "Required")]
        [MaxLength(100, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MaxLength")]
        [EmailAddress(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "WrongInput")]
        [Display(Name = nameof(ViewModel.Email), ResourceType = typeof(ViewModel))]
        public string Email { get; set; }
    }
}