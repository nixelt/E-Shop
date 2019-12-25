namespace E_Shop.ViewModels.ProductViewModels
{
    using System.Collections.Generic;

    public class ProductFilterViewModel
    {
        public int CategoryId { get; set; }

        public int MinPrice { get; set; }

        public int MaxPrice { get; set; }

        public int OrderBy { get; set; }

        public List<AttributeValueViewModel> CheckedAttributes { get; set; }
    }
}