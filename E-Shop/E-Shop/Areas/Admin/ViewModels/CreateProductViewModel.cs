using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Shop.Areas.Admin.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using E_Shop.Model.Models;
    using E_Shop.ViewModels;

    public class CreateProductViewModel
    {
        [Required(ErrorMessage = "Обязательное поле")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        public int Price { get; set; }
        public int OldPrice { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        public string Warranty { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        public int CategoryId { get; set; }
        public List<HttpPostedFileBase> Images { get; set; }
        public List<IndexCategoryViewModel> Categories { get; set; }
    }
}