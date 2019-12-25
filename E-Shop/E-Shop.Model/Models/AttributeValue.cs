using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Model.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AttributeValue
    {
        public int AttributeValueId { get; set; }
        [Required]
        public string Value { get; set; }
        [Required]
        public int AttributeId { get; set; }
        [Required]
        public int ProductId { get; set; }

        public virtual Attribute Attribute { get; set; }

        public virtual Product Product { get; set; }
    }
}
