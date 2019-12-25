using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Model.Models
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
