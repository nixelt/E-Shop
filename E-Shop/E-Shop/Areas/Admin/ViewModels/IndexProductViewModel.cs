using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Shop.Areas.Admin.ViewModels
{
    using System.ComponentModel;

    public class IndexProductViewModel
    {
        public int ProductId { get; set; }
        [DisplayName("Название")]
        public string Name { get; set; }
        [DisplayName("Цена")]
        public int Price { get; set; }
        public int OldPrice { get; set; }
        [DisplayName("Количество")]
        public int Quantity { get; set; }
    }
}