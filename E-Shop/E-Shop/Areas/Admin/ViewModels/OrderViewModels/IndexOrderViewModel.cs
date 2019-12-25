namespace E_Shop.Areas.Admin.ViewModels.OrderViewModels
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using E_Shop.ViewModels.PagerViewModel;

    public class IndexOrderViewModel
    {
        public List<SelectListItem> OrderStatuses { get; set; }

        public PagerViewModel<OrderViewModel> OrderList { get; set; }

        public int? OrderStatusId { get; set; }

        public string OnlyMyOrders { get; set; }

        public int Page { get; set; } = 1;
    }
}