namespace E_Shop.ViewModels.SettingsViewModels
{
    public class SettingsViewModel
    {
        public ContactInfoViewModel UserInfo { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public bool EmailConfirmed { get; set; }

        public bool TwoFactorEnabled { get; set; }
    }
}