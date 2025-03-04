﻿namespace E_Shop.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Supply
    {
        public int SupplyId { get; set; }

        [Required]
        public int SupplierId { get; set; }

        public DateTime SupplyDate { get; set; }

        public virtual Supplier Supplier { get; set; }

        public virtual List<SupplyProduct> SupplyProducts { get; set; }
    }
}
