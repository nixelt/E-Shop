namespace E_Shop.Model
{
    using System.ComponentModel.DataAnnotations;

    public class ProductImage
    {
        public int ProductImageId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public byte[] Image { get; set; }

        public virtual Product Product { get; set; }
    }
}
