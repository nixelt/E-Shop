using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.Model.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class Attribute
    {
        public int AttributeId { get; set; }
        [Required]
        public string Name { get; set; }
        [DefaultValue(false)]
        public bool AllowFiltering { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<AttributeValue> AttributeValues { get; set; }
    }
}
