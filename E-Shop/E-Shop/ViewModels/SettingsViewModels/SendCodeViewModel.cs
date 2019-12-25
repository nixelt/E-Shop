namespace E_Shop.ViewModels.SettingsViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using App_LocalResources;

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }

        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }

        public string ReturnUrl { get; set; }
        [Display(Name = nameof(ViewModel.RememberMe), ResourceType = typeof(ViewModel))]
        public bool RememberMe { get; set; }
    }
}