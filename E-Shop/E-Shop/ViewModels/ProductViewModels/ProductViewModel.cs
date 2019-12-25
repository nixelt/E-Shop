namespace E_Shop.ViewModels.ProductViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public int OldPrice { get; set; }

        public byte[] Image { get; set; }

        public bool InStock { get; set; }
    }
}