namespace E_Shop.Areas.Admin.ViewModels.UserViewModels
{
    using E_Shop.ViewModels.PagerViewModel;

    using OrderViewModels;

    public class DetailsUserViewModel : UserViewModel
    {
        public PagerViewModel<OrderViewModel> Orders { get; set; }

    }
}