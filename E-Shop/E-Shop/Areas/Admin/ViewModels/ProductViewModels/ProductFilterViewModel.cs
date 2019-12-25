namespace E_Shop.Areas.Admin.ViewModels.ProductViewModels
{
    public class ProductFilterViewModel
    {
        public bool OnlyDeleted { get; set; }

        public string Search { get; set; }

        public int? CategoryId { get; set; }
    }
}