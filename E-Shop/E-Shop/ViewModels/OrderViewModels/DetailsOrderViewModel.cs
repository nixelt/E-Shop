namespace E_Shop.ViewModels.OrderViewModels
{
    using System.Collections.Generic;

    public class DetailsOrderViewModel : OrderViewModel
    {
        public string Comment { get; set; }

        public List<OrderDetailsViewModel> OrderDetails { get; set; }

        public LiqPayCheckoutFormModel LiqPayCheckoutFormModel { get; set; }
    }
}