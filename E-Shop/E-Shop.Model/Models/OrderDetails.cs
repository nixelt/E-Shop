using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Model.Models
{
    using System.ComponentModel.DataAnnotations;

    public class OrderDetails
    {
        public int OrderDetailsId { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int ProductPrice { get; set; }

        public virtual Order Order { get; set; }
        
        public virtual Product Product { get; set; }
    }
}
