using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Model.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Price { get; set; }
        public int OldPrice { get; set; }
        [Required]
        public string Warranty { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<AttributeValue> AttributeValues { get; set; }
        public virtual List<ProductImage> Images { get; set; }
    }
}
