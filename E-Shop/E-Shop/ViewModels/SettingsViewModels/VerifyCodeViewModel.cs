namespace E_Shop.ViewModels.SettingsViewModels
{
    using System.ComponentModel.DataAnnotations;

    using App_LocalResources;

    public class VerifyCodeViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "Required")]
        [Display(Name = nameof(ViewModel.Provider), ResourceType = typeof(ViewModel))]
        public string Provider { get; set; }

        [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "Required")]
        [Display(Name = nameof(ViewModel.Code), ResourceType = typeof(ViewModel))]
        public string Code { get; set; }

        public string ReturnUrl { get; set; }

        [Display(Name = nameof(ViewModel.RememberBrowser), ResourceType = typeof(ViewModel))]
        public bool RememberBrowser { get; set; }

        [Display(Name = nameof(ViewModel.RememberMe), ResourceType = typeof(ViewModel))]
        public bool RememberMe { get; set; }
    }
}