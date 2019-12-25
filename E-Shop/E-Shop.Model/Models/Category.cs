using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Model.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public byte[] Image { get; set; }

        public virtual List<Attribute> Attributes { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
