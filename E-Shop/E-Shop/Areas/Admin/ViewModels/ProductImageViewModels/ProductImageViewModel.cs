namespace E_Shop.Areas.Admin.ViewModels.ProductImageViewModels
{
    using System.ComponentModel.DataAnnotations;

    using App_LocalResources;

    public class ProductImageViewModel
    {
        public int ProductImageId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "Required")]
        public int ProductId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "Required")]
        public byte[] Image { get; set; }
    }
}