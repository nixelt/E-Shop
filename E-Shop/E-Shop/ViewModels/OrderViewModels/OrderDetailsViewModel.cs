namespace E_Shop.ViewModels.OrderViewModels
{
    using System.ComponentModel;

    public class OrderDetailsViewModel
    {
        public int ProductId { get; set; }
        [DisplayName("Название")]
        public string Name { get; set; }
        [DisplayName("Количество")]
        public int QuantityInCart { get; set; }
        [DisplayName("Цена")]
        public int Price { get; set; }
    }
}