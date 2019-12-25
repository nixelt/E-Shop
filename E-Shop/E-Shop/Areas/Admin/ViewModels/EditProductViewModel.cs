using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Shop.Areas.Admin.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class EditProductViewModel
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        public int Price { get; set; }
        public int OldPrice { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        public string Warranty { get; set; }
        public int CategoryId { get; set; }
        public int Quantity { get; set; }
    }
}