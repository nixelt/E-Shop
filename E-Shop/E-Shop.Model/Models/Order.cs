using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Model.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Order
    {
        public Order()
        {
            OrderDate = DateTime.Now;
        }

        public int OrderId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Phone]
        [Required]
        public int Phone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        [Required]
        public string CustomerId { get; set; }
        public string ManagerId { get; set; }

        public virtual User Customer { get; set; }
        public virtual User Manager { get; set; }
        public virtual List<OrderDetails> OrderDetails { get; set; }
    }
}
