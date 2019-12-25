namespace E_Shop.Areas.Admin.ViewModels.UserViewModels
{
    using System.ComponentModel.DataAnnotations;

    using App_LocalResources;

    public class UserViewModel
    {
        public string Id { get; set; }
        [Display(Name = nameof(ViewModel.FullName), ResourceType = typeof(ViewModel))]
        public string FullName { get; set; }
        [Display(Name = nameof(ViewModel.Phone), ResourceType = typeof(ViewModel))]
        public string PhoneNumber { get; set; }

        [Display(Name = nameof(ViewModel.Email), ResourceType = typeof(ViewModel))]
        public string Email { get; set; }

        [Display(Name = nameof(ViewModel.Blocked), ResourceType = typeof(ViewModel))]
        public bool IsBlocked { get; set; }
    }
}